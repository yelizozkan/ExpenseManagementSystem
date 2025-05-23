﻿using ExpenseManagementSystem.Application.Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("expenses")]
        public async Task<IActionResult> GetPersonalExpenseReport()
        {
            var result = await _reportService.GetPersonalExpenseReportAsync();
            return Ok(result);
        }



        [HttpGet("payment-density")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPaymentDensity([FromQuery] string type = "daily")
        {
            var result = await _reportService.GetPaymentDensityAsync(type);
            return Ok(result);
        }



        [HttpGet("user-expenditure-density")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserExpenditureDensity([FromQuery] string type = "daily")
        {
            var result = await _reportService.GetUserExpenditureDensityAsync(type);
            return Ok(result);
        }



        [HttpGet("approval-summary")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetApprovalSummary([FromQuery] string type = "daily")
        {
            var result = await _reportService.GetApprovalSummaryAsync(type);
            return Ok(result);
        }

    }

}
