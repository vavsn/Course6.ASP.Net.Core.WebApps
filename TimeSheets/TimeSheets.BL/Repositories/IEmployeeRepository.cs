using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public interface IEmployeeRepository : IEmpRepository<Employee>
    {

    }
    public interface IEmpRepository<T> where T : class
    {
        Task Create(T entity);

        Task<IReadOnlyCollection<T>> Get();

        Task Update(T entity);

        Task Delete(T id);
    }
}
