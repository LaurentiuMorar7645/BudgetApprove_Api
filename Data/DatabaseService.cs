using Microsoft.EntityFrameworkCore;
using BudgetApprovedApi.Models;

namespace BudgetApprovedApi.Data
{
    public class DatabaseService : DbContext
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options) {}

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ExpenseModel> Expenses { get; set; }
    }
}
