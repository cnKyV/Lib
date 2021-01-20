using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IContactService
    {
        ICollection<Contact> GetAll();
        Contact GetById(int Id);
        Contact Create(Contact author);
        Contact Update(Contact author);
    }
}
