using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        public ICreateModel Create(ICreateModel Repository)
        {
            throw new NotImplementedException();
        }

        public ICollection<ContactViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ContactViewModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IUpdateModel Update(IUpdateModel Repository)
        {
            throw new NotImplementedException();
        }
    }
}
