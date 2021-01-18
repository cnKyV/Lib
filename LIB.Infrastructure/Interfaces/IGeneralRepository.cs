using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    interface IGeneralRepository<T>
    {
        ICollection<T> GetAll();
        T GetById(int id);
        T Create(T TEntity);
        T Update(T TEntity);
        bool Clear();
        bool DeleteById(int id);
        void SaveChanges();
    }
}
