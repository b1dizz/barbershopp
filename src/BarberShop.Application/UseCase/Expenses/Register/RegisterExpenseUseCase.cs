using AutoMapper;
using BarberShop.Communication.Requests;
using BarberShop.Communication.Responses;
using BarberShop.Domain.Entities;
using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Expenses;
using BarberShop.Exception.ExceptionsBase;

namespace BarberShop.Application.UseCase.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpenseWriteOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public RegisterExpenseUseCase(
        IExpenseWriteOnlyRepository repository, 
        IUnityOfWork unityOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Expense>(request);

        await _repository.Add(entity);

        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisteredExpenseJson>(entity);
    }

    private void Validate(RequestExpenseJson request)
    {
        var validator = new ExpenseValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {

            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
