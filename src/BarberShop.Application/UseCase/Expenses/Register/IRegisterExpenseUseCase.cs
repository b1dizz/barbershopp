using BarberShop.Communication.Requests;
using BarberShop.Communication.Responses;

namespace BarberShop.Application.UseCase.Expenses.Register;
public interface IRegisterExpenseUseCase
{
    Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request);
}
