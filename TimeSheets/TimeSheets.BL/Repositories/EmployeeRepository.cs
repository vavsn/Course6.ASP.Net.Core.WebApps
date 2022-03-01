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

        public async Task Add(Employee entity)
        {
            entity.IsDelete = false;
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Employee>> Get()
        {
            var emp = await _context.Employees.ToListAsync();
            return emp;
        }

        public async Task Update(Employee entity)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(en => en.Id == entity.Id);
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
            var user = await _context.Employees.FirstOrDefaultAsync(en => en.Id == id);
            user.IsDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Employee _emp)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(en => en.Id == _emp.Id);
            emp.IsDelete = true;
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }
    }
}
