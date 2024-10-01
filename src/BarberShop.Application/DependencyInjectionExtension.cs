using BarberShop.Application.AutoMapper;
using BarberShop.Application.UseCase.Expenses.Delete;
using BarberShop.Application.UseCase.Expenses.Excel;
using BarberShop.Application.UseCase.Expenses.GetAll;
using BarberShop.Application.UseCase.Expenses.GetById;
using BarberShop.Application.UseCase.Expenses.Pdf;
using BarberShop.Application.UseCase.Expenses.Register;
using BarberShop.Application.UseCase.Expenses.Update;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IGetAllExpenseUseCase, GetAllExpenseUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
        services.AddScoped<IGenerateExpensesReportExcelUseCase, GenerateExpensesReportExcelUseCase>();
        services.AddScoped<IGenerationExpensesReportPdfUseCase, GenerationExpensesReportPdfUseCase>();
    }
}
