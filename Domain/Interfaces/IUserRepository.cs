using ExpenseTrackerAPI.Domain.Entites;

namespace ExpenseTrackerAPI.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> RegisterUserAsync(User user);
        //Task<bool> UserExistsAsync(string email);
        //Task<string> GetUserPasswordHashAsync(string email);
        Task<User?> GetUserByEmailAsync(string email);
        // Additional methods for user management can be added here
    }
}
