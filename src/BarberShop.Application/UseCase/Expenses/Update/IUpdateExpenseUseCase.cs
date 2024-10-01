
namespace BarberShop.Application.UseCase.Expenses.Update;
public interface IUpdateExpenseUseCase
{
    Task Execute(long id, Communication.Requests.RequestExpenseJson request);
}
