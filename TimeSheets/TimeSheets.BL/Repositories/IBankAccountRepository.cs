
using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public interface IBankAccountRepository : IBARepository<BankAccount>
    {

    }
    public interface IBARepository<T> where T : class
    {
        Task Add();
        Task<IReadOnlyCollection<T>> Get();
        Task Operation(T entity);
        Task Close(T entity);
    }

}