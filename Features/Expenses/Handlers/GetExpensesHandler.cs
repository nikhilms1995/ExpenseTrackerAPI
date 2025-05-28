using ExpenseTrackerAPI.Domain.Entites;
using ExpenseTrackerAPI.Domain.Interfaces;
using ExpenseTrackerAPI.Features.Expenses.Queries;
using ExpenseTrackerAPI.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Features.Expenses.Handlers
{
    public class GetExpensesHandler : IRequestHandler<GetExpensesQuery, List<Expense>>
    {
        private readonly IExpenseRepository _expenseRepository;

        public GetExpensesHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository ?? throw new ArgumentNullException(nameof(expenseRepository));
        }

        public async Task<List<Expense>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
        {
            return await _expenseRepository.GetAllExpensesAsync(request.UserId)
                .ConfigureAwait(false) as List<Expense> ?? new List<Expense>();
        }
    }
}
