using BarberShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infrastructure.DataAccess;

internal class BarberShopDbContext : DbContext
{
    public BarberShopDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Expense> Expenses {  get; set; }

}
