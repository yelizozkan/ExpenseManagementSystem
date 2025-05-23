﻿using ExpenseManagementSystem.Application.Dtos.Category;
using ExpenseManagementSystem.Application.Features.Categories.Commands.CreateCategory;
using ExpenseManagementSystem.Application.Features.Categories.Commands.DeleteCategory;
using ExpenseManagementSystem.Application.Features.Categories.Commands.UpdateCategory;
using ExpenseManagementSystem.Application.Features.Categories.Queries.GetAllCategories;
using ExpenseManagementSystem.Application.Features.Categories.Queries.GetCategoryById;
using ExpenseManagementSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin,Personnel")]
        public async Task<ApiResponse<List<CategoryResponseDto>>> GetAll()
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);
            return new ApiResponse<List<CategoryResponseDto>>(result);
        }


        [HttpGet("GetById/{id}")]
        [Authorize(Roles = "Admin,Personnel")]
        public async Task<ApiResponse<CategoryResponseDto>> GetById([FromRoute] long id)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await _mediator.Send(query);
            return new ApiResponse<CategoryResponseDto>(result);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResponse<CategoryResponseDto>> Post([FromBody] CategoryRequestDto category)
        {
            var command = new CreateCategoryCommand(category);
            var result = await _mediator.Send(command);
            return new ApiResponse<CategoryResponseDto>(result);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResponse> Put([FromRoute] long id, [FromBody] CategoryRequestDto category)
        {
            await _mediator.Send(new UpdateCategoryCommand(id, category));
            return new ApiResponse("Kategori güncellendi", true);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResponse> Delete([FromRoute] long id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            return result
                ? new ApiResponse("Kategori silindi", true)
                : new ApiResponse("Kategori silinemedi veya bulunamadı", false);
        }
    }
}
