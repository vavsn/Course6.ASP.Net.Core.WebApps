﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        T GetByName(string name);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
