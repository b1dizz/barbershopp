
using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Expenses;
using BarberShop.Exception;

namespace BarberShop.Application.UseCase.Expenses.Delete;

public class DeleteExpenseUseCase : IDeleteExpenseUseCase
{
    private readonly IExpenseWriteOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;


    public DeleteExpenseUseCase(IExpenseWriteOnlyRepository repository, IUnityOfWork unityOfWork)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);
        
        if (result == false)
        {
            throw new ArgumentException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        await _unityOfWork.Commit();
    }
}
