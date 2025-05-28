using ExpenseTrackerAPI.Domain.Entites;

namespace ExpenseTrackerAPI.Domain.Interfaces
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync(Guid userId);
        //Task<Expense> GetExpenseByIdAsync(Guid expenseId);
        //Task AddExpenseAsync(Expense expense);
        //Task UpdateExpenseAsync(Expense expense);
        //Task DeleteExpenseAsync(Guid expenseId);
    }
}
