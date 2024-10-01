
using BarberShop.Communication.Responses;

namespace BarberShop.Application.UseCase.Expenses.GetAll;
public interface IGetAllExpenseUseCase
{
    Task<ResponseExpenseJson> Execute();
}
