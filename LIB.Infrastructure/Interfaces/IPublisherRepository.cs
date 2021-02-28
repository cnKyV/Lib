using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IPublisherRepository
    {
        ICollection<Publisher> GetAll();
        Publisher GetById(int id);
        Publisher Create(Publisher TEntity);
        Publisher Update(Publisher TEntity);
        bool DeleteById(int id);
        public IEnumerable<Publisher> GetMultipleByIds(IEnumerable<int> ids);
        void SaveChanges();

    }
}
