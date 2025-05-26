using ExpenseTrackerAPI.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Infrastructure.Data
{
    public class ExpenseTrackerDbContext : DbContext
    {
        public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Expense> Expenses { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User entity
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            // Expense entity
            modelBuilder.Entity<Expense>()
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Expense>()
                .HasOne(e => e.User)
                .WithMany(u => u.Expenses)
                .HasForeignKey(e => e.UserId);
        }
    }
}
