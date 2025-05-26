namespace ExpenseTrackerAPI.Domain.Entites
{
    public class Expense
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public string? Notes { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
