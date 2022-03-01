using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL;
using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task Add(User entity)
        {
            entity.IsDelete = false;
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<User>> Get()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task Update(User entity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(en => en.Id == entity.Id);
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            user.Company = entity.Company;
            user.Age = entity.Age;
            user.IsDelete = entity.IsDelete;
            user.Division = entity.Division;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(en => en.Id == id);
            user.IsDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User _user)
        {
            var user = await _context.Users.FirstOrDefaultAsync(en => en.Id == _user.Id);
            user.IsDelete = true;
            await _context.SaveChangesAsync();
        }
    }
}
