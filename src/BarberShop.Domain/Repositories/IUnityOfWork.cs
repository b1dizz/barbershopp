namespace BarberShop.Domain.Repositories;
public interface IUnityOfWork
{
    Task Commit();
}
