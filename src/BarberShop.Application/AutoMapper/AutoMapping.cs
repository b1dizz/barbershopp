using AutoMapper;
using BarberShop.Communication.Requests;
using BarberShop.Communication.Responses;
using BarberShop.Domain.Entities;

namespace BarberShop.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestExpenseJson, Expense>();
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisteredExpenseJson>();
        CreateMap<Expense, ResponseShortExpenseJson>();
        CreateMap<Expense, ResponseAllExpenseJson>();
    }
}
