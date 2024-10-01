using BarberShop.Communication.Responses;

namespace BarberShop.Application.UseCase.Expenses.GetById;
public interface IGetExpenseByIdUseCase
{
    Task<ResponseAllExpenseJson> Execute(long id);
}
