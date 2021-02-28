using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using LIB.Contracts.RequestModel;

namespace LIB.Infrastructure.Interfaces
{
    public interface IContactRepository
    {
        Contact Update(Contact TEntity);
        void SaveChanges();
    }
}
