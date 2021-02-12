using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IPublisherService 
    {
        ICollection<Publisher> GetAll();
        Publisher GetById(int Id);
        Publisher Create(Publisher publisher);
        Publisher Update(Publisher publisher);
        bool DeleteById(int id);
        public IEnumerable<Publisher> GetMultipleByIds(IEnumerable<int> ids);

    }
}
