
namespace BarberShop.Application.UseCase.Expenses.Pdf;
public interface IGenerationExpensesReportPdfUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
