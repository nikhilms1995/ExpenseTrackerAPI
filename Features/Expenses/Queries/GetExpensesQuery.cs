using ExpenseTrackerAPI.Domain.Entites;
using MediatR;

namespace ExpenseTrackerAPI.Features.Expenses.Queries
{
    public record GetExpensesQuery(Guid UserId) : IRequest<List<Expense>>
    {
    }
}
