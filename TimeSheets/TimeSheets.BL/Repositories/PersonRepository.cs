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

        public async Task Create(Person entity)
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

        public async Task<IReadOnlyCollection<Person>> Get()
        {
            var persons = await _context.Persons.ToListAsync();
            return persons;
        }

        public async Task Update(Person entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("Отсутствуют данные для записи", nameof(entity));
            }
            var person = await _context.Persons.FirstOrDefaultAsync(en => en.Id == entity.Id);
            if (person is null)
            {
                throw new ArgumentNullException("Не найдена запись о сотруднике", nameof(entity));
            }
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
            if (personId < 0)
            {
                throw new ArgumentNullException("Не корректные данные для удаления", nameof(personId));
            }
            var person = await _context.Persons.FirstOrDefaultAsync(en => en.Id == personId);
            if (person is null)
            {
                throw new ArgumentNullException("Не найдена запись о сотруднике", nameof(personId));
            }
            person.IsDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Person _person)
        {
            if (_person is null)
            {
                throw new ArgumentNullException("Не корректные данные для удаления", nameof(_person));
            }
            var person = await _context.Persons.FirstOrDefaultAsync(en => en.Id == _person.Id);
            if (person is null)
            {
                throw new ArgumentNullException("Не найдена запись о сотруднике", nameof(_person));
            }
            person.IsDelete = true;
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }
    }
}
