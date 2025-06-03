using ExpenseTrackerAPI.Features.Expenses.Commands;
using ExpenseTrackerAPI.Features.Expenses.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : BaseController
    {

        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpensesByUser()
        {
            if (UserId == null)
                return Unauthorized();
            var expenses = await _mediator.Send(new GetExpensesQuery(UserId.Value));
            return Ok(expenses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid expense data.");
            }
            var expenseId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetExpensesByUser), new { userId = command.UserId }, expenseId);
        }
    }
}
