using Microsoft.EntityFrameworkCore;
using TmSheets.DAL.Models;
using TmSheets.DAL;

namespace TimeSheets.BL.Repositories
{
    public class PersonRepository
    {
        private readonly MyDbContext _context;

        public PersonRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task Add(Person entity)
        {
            entity.IsDelete = false;
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Person>> Get()
        {
            var persons = await _context.Persons.ToListAsync();
            return persons;
        }

        public async Task Update(Person entity)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(en => en.Id == entity.Id);
            person.FirstName = entity.FirstName;
            person.LastName = entity.LastName;
            person.Email = entity.Email;
            person.Company = entity.Company;
            person.Age = entity.Age;
            person.IsDelete = entity.IsDelete;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(en => en.Id == id);
            person.IsDelete = true;
            await _context.SaveChangesAsync();
        }
    }
}
