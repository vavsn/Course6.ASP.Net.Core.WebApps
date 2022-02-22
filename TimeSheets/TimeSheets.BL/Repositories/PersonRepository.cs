using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL;
using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public class PersonRepository : IPersonRepository
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

        public async Task Delete(int personId)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(en => en.Id == personId);
            person.IsDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Person _person)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(en => en.Id == _person.Id);
            person.IsDelete = true;
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }
    }
}
