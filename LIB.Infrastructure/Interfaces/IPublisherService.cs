using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IPublisherService
    {
        ICollection<Publisher> GetAll();
        Publisher GetById(int id);
        Publisher Create(Publisher publisher);
        Publisher Update(Publisher publisher);
        bool Clear();
        bool DeleteById(int id);
    }
}
