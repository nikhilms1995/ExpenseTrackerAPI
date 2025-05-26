using MediatR;

namespace ExpenseTrackerAPI.Features.Expenses.Commands
{
    public record CreateExpenseCommand(
    string Title,
    decimal Amount,
    string Category,
    string? Notes,
    Guid UserId
) : IRequest<Guid>;
}
