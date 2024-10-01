
namespace BarberShop.Application.UseCase.Expenses.Excel;
public interface IGenerateExpensesReportExcelUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
