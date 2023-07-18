using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Data.Contexts;

public class BankingDbContext : DbContext
{
    public BankingDbContext()
    {
    }
    
    public BankingDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Account> Accounts { get; set; }
}