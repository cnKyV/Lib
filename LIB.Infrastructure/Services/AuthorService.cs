using LIB.Contracts.RequestModel;
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
    public class AuthorService : IAuthorService
    {
        public ICreateModel Create(AuthorRepository Repository)
        {
            throw new NotImplementedException();
        }

        public ICollection<AuthorViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AuthorViewModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IUpdateModel Update(AuthorRepository Repository)
        {
            throw new NotImplementedException();
        }
    }
}
