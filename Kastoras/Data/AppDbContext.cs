using Kastoras.Models;
using Microsoft.EntityFrameworkCore;

namespace Kastoras.Data;

public class AppDbContext : DbContext
{
    // public DbSet<Transaction> Transactions { get; set; }
    // public DbSet<Category> Categories { get; set; }
    // public DbSet<Budget> Budgets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=kastaros.db");
    }
}