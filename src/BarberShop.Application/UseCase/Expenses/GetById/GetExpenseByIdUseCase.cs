using AutoMapper;
using BarberShop.Communication.Responses;
using BarberShop.Domain.Repositories.Expenses;
using BarberShop.Exception;
using BarberShop.Exception.ExceptionsBase;

namespace BarberShop.Application.UseCase.Expenses.GetById;

public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetExpenseByIdUseCase(IExpensesReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseAllExpenseJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        return _mapper.Map<ResponseAllExpenseJson>(result);
    }
}
