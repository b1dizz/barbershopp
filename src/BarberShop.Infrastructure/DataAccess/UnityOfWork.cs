using BarberShop.Domain.Repositories;

namespace BarberShop.Infrastructure.DataAccess;

internal class UnityOfWork : IUnityOfWork
{
    private readonly BarberShopDbContext _dbContext;

    public UnityOfWork(BarberShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
