using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL;
using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyDbContext _context;

        public EmployeeRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task Create(Employee entity)
        {
            try
            {
                entity.IsDelete = false;
                _context.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не удалось записать данные");
            }
        }

        public async Task<IReadOnlyCollection<Employee>> Get()
        {
            var emp = await _context.Employees.ToListAsync();
            return emp;
        }

        public async Task Update(Employee entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("Отсутствуют данные для записи", nameof(entity));
            }
            var emp = await _context.Employees.FirstOrDefaultAsync(en => en.Id == entity.Id);
            if (emp is null)
            {
                throw new ArgumentNullException("Не найдена запись о сотруднике", nameof(entity));
            }
            emp.FirstName = entity.FirstName;
            emp.LastName = entity.LastName;
            emp.Email = entity.Email;
            emp.Company = entity.Company;
            emp.Age = entity.Age;
            emp.IsDelete = entity.IsDelete;
            emp.Division = entity.Division;
            emp.Department = entity.Department;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException("Не корректные данные для удаления", nameof(id));
            }
            var user = await _context.Employees.FirstOrDefaultAsync(en => en.Id == id);
            if (user is null)
            {
                throw new ArgumentNullException("Не найдена запись о сотруднике", nameof(id));
            }
            user.IsDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Employee _emp)
        {
            if (_emp is null)
            {
                throw new ArgumentNullException("Не корректные данные для удаления", nameof(_emp));
            }
            var emp = await _context.Employees.FirstOrDefaultAsync(en => en.Id == _emp.Id);
            if (emp is null)
            {
                throw new ArgumentNullException("Не найдена запись о сотруднике", nameof(_emp));
            }
            emp.IsDelete = true;
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }
    }
}
