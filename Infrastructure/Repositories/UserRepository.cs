using Azure.Core;
using ExpenseTrackerAPI.Domain.Entites;
using ExpenseTrackerAPI.Domain.Interfaces;
using ExpenseTrackerAPI.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ExpenseTrackerAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseTrackerDbContext _expenseTrackerDbContext;
        public UserRepository(ExpenseTrackerDbContext expenseTrackerDbContext) 
        { 
            _expenseTrackerDbContext = expenseTrackerDbContext ?? throw new ArgumentNullException(nameof(expenseTrackerDbContext));
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _expenseTrackerDbContext.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));
        }

        public async Task<Guid> RegisterUserAsync(User user)
        {
            _expenseTrackerDbContext.Users.Add(user);
            await _expenseTrackerDbContext.SaveChangesAsync();
            return user.Id;
        }
    }
}
