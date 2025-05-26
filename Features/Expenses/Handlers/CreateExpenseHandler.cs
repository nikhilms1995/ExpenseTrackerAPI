using ExpenseTrackerAPI.Domain.Entites;
using ExpenseTrackerAPI.Features.Expenses.Commands;
using ExpenseTrackerAPI.Infrastructure.Data;
using MediatR;
using System;

namespace ExpenseTrackerAPI.Features.Expenses.Handlers
{
    public class CreateExpenseHandler : IRequestHandler<CreateExpenseCommand, Guid>
    {
        private readonly ExpenseTrackerDbContext _context;

        public CreateExpenseHandler(ExpenseTrackerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Guid> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense
            {
                Title = request.Title,
                Amount = request.Amount,
                Category = request.Category,
                Notes = request.Notes,
                UserId = request.UserId,
                Date = DateTime.UtcNow
            };
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync(cancellationToken);
            return expense.Id;
        }
    }
}
