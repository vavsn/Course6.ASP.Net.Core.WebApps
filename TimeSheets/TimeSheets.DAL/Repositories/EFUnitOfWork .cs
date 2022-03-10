using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Entities;
using TimeSheets.DAL.Interfaces;

namespace TimeSheets.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private List<Person> _person;
        private bool disposedValue;

        public EFUnitOfWork(List<Person> pers)
        {
            this._person = pers;
        }

        public IRepository<Person> Persons => (IRepository<Person>)_person;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
