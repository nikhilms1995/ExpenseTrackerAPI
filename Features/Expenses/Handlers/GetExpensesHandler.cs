using ExpenseTrackerAPI.Domain.Entites;
using ExpenseTrackerAPI.Features.Expenses.Queries;
using ExpenseTrackerAPI.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Features.Expenses.Handlers
{
    public class GetExpensesHandler : IRequestHandler<GetExpensesQuery, List<Expense>>
    {
        private readonly ExpenseTrackerDbContext _context;

        public GetExpensesHandler(ExpenseTrackerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Expense>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Expenses
                .Where(e => e.UserId == request.UserId)
                .ToListAsync(cancellationToken);
        }
    }
}
