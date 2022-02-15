using System;
using TimeSheets.DAL.Entities;

namespace TimeSheets.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Person> Persons { get; }

    }
}
