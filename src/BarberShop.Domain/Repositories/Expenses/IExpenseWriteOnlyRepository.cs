using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Repositories.Expenses;
public interface IExpenseWriteOnlyRepository
{
    Task Add(Expense expense);
    /// <summary>
    /// This function return true if the deletion was sucessful otherwise returns false.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
