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
            var person = _person[item.Id];
            if (person is not null)
            {
                throw new Exception("Данные уже есть");
            }
            this._person.Add(item);
        }

        public void Delete(int id)
        {
            Person person = _person[id];
            if (person is null)
            {
                throw new Exception("Указан отсутствующий ID");
            }
            _person.Remove(person);
        }
        public Person GetById(int id)
        {
            Person person = _person[id];
            if (person is null)
            {
                throw new Exception("Указан отсутствующий ID");
            }
            return _person[id];
        }

        public Person GetByName(string name)
        {
            Person person = Search(name);
            if (person is null)
            {
                throw new Exception("Данные не найдены");
            }
            return person;
        }

        public void Update(Person item)
        {
            var person = Search(item.FirstName);
            if (person is null)
            {
                throw new Exception("Данные не найдены");
            }
            person = item;
        }
    }
}
