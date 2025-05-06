using ExpenseManagementSystem.Application.Exceptions;
using ExpenseManagementSystem.Application.Responses;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace ExpenseManagementSystem.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                return; // exception sonrası yazmaya devam etme
            }

            if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                context.Response.ContentType = "application/json";
                var response = new ApiResponse("Bu işlemi yapmak için yetkiniz yok.");
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
            else if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                context.Response.ContentType = "application/json";
                var response = new ApiResponse("Kimlik doğrulaması gerekli.");
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "Bir hata oluştu:");

            var response = new ApiResponse
            {
                Success = false,
                Message = exception.Message
            };

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                ConflictException => (int)HttpStatusCode.Conflict,
                ValidationException => (int)HttpStatusCode.BadRequest,
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}
