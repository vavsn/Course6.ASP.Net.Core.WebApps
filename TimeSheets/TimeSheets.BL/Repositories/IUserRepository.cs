using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{

    public interface IUserRepository : IUsRepository<User>
    {

    }
    public interface IUsRepository<T> where T : class
    {
        Task Create(T entity);

        Task<IReadOnlyCollection<T>> Get();

        Task Update(T entity);

        Task Delete(T id);
    }

}
