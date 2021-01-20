using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IContactRepository
    {
        ICollection<Contact> GetAll();
        Contact GetById(int id);
        Contact Create(Contact TEntity);
        Contact Update(Contact TEntity);
        bool Clear();
        bool DeleteById(int id);
    }
}
