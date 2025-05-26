using ExpenseTrackerAPI.Features.Expenses.Commands;
using ExpenseTrackerAPI.Features.Expenses.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetExpensesByUser(Guid userId)
        {
            var expenses = await _mediator.Send(new GetExpensesQuery(userId));
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
