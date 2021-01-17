using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    interface IContactRepository
    {
        ICollection<Contact> GetAll();
        Contact GetById(int id);
        Contact Create(Contact contact);
        Contact Update(Contact contact);
        bool Clear();
        bool DeleteById(int id);
        void SaveChanges();
    }
}
