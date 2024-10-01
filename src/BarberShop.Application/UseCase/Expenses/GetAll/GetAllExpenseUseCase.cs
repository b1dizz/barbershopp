using AutoMapper;
using BarberShop.Communication.Responses;
using BarberShop.Domain.Repositories.Expenses;

namespace BarberShop.Application.UseCase.Expenses.GetAll;

public class GetAllExpenseUseCase : IGetAllExpenseUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    
    
    public GetAllExpenseUseCase(IExpensesReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseExpenseJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseExpenseJson
        {
            Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
        };
    }
}

