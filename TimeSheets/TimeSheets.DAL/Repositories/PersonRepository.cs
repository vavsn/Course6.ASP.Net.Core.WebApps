using System;
using System.Collections.Generic;
using TimeSheets.DAL.Entities;
using TimeSheets.DAL.Interfaces;

namespace TimeSheets.DAL.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private List<Person> _person;
        private Person Search(string firstName)
        {
            return _person.Find(p => Equals(p.FirstName, firstName));
        }

        public PersonRepository(List<Person> pers)
        {
            this._person = pers;
        }
        public void Create(Person item)
        {
            this._person.Add(item);
        }

        public void Delete(int id)
        {
            Person person = _person[id];
            if (person!= null)
                _person.Remove(person);
        }
        public Person GetById(int id)
        {
            return _person[id];
        }

        public Person GetByName(string name)
        {
            return Search(name);
        }

        public void Update(Person item)
        {
            var srchPerson = Search(item.FirstName);
            if (srchPerson is not null)
            {
                srchPerson = item;
            }
        }
    }
}
