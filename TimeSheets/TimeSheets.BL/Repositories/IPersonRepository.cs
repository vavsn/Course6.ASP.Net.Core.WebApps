using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {

    }
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);

        Task<IReadOnlyCollection<T>> Get();

        Task Update(T entity);

        Task Delete(T id);
    }
}
