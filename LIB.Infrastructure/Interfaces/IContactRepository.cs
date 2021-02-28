using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using LIB.Contracts.RequestModel;

namespace LIB.Infrastructure.Interfaces
{
    public interface IContactRepository
    {
        ICollection<Contact> GetAll();
        Contact GetById(int id);
        Contact Create(Contact TEntity);
        Contact Update(Contact TEntity);
        bool DeleteById(int id);
    }
}
