using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.BL.DTO;

namespace TimeSheets.BL.Services
{
    public class PersonService : IPersonService<PersonDTO>
    {
        private List<PersonDTO> _person;
        private PersonDTO Search(string firstName)
        {
            return _person.Find(p => Equals(p.FirstName, firstName));
        }

        public PersonService(List<PersonDTO> pers)
        {
            this._person = pers;
        }
        public void Create(PersonDTO item)
        {
            this._person.Add(item);
        }

        public void Delete(int id)
        {
            PersonDTO person = _person[id];
            if (person != null)
                _person.Remove(person);
        }
        public PersonDTO GetById(int id)
        {
            return _person[id];
        }

        public PersonDTO GetByName(string name)
        {
            return Search(name);
        }

        public void Update(PersonDTO item)
        {
            var srchPerson = Search(item.FirstName);
            if (srchPerson is not null)
            {
                srchPerson = item;
            }
        }
    }
}
