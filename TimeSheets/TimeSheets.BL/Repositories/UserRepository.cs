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

        public async Task Create(User entity)
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

        public async Task<IReadOnlyCollection<User>> Get()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task Update(User entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("Отсутствуют данные для записи", nameof(entity));
            }
            var user = await _context.Users.FirstOrDefaultAsync(en => en.Id == entity.Id);
            if (user is null)
            {
                throw new ArgumentNullException("Не найдена запись о сотруднике", nameof(entity));
            }
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
            if (id < 0)
            {
                throw new ArgumentNullException("Не корректные данные для удаления", nameof(id));
            }
            var user = await _context.Users.FirstOrDefaultAsync(en => en.Id == id);
            if (user is null)
            {
                throw new ArgumentNullException("Не найдена запись о сотруднике", nameof(id));
            }
            user.IsDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User _user)
        {
            if (_user is null)
            {
                throw new ArgumentNullException("Не корректные данные для удаления", nameof(_user));
            }
            var user = await _context.Users.FirstOrDefaultAsync(en => en.Id == _user.Id);
            if (user is null)
            {
                throw new ArgumentNullException("Не найдена запись о сотруднике", nameof(_user));
            }
            user.IsDelete = true;
            await _context.SaveChangesAsync();
        }
    }
}
