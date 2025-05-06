using System.Text.Json;

namespace ExpenseManagementSystem.Application.Responses
{
    public class ApiResponse
    {
        public override string ToString() => JsonSerializer.Serialize(this);

        public ApiResponse() { }

        public ApiResponse(string message)
        {
            Success = false;
            Message = message;
        }

        public ApiResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public DateTime ServerDate { get; set; } = DateTime.UtcNow;
        public Guid ReferenceNo { get; set; } = Guid.NewGuid();
    }

    public class ApiResponse<T>
    {
        public DateTime ServerDate { get; set; } = DateTime.UtcNow;
        public Guid ReferenceNo { get; set; } = Guid.NewGuid();
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }

        public ApiResponse(bool isSuccess)
        {
            Success = isSuccess;
            Response = default;
            Message = isSuccess ? "Success" : "Error";
        }
        public ApiResponse(T data)
        {
            Success = true;
            Response = data;
            Message = "Success";
        }
        public ApiResponse(string message)
        {
            Success = false;
            Response = default;
            Message = message;
        }
        public ApiResponse(string message, bool success)
        {
            Success = success;
            Message = message;
            Response = default;
        }
    }
}
