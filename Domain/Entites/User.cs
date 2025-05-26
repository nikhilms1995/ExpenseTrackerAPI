namespace ExpenseTrackerAPI.Domain.Entites
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
