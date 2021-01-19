using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        public AuthorCreateResponseModel Create(Author TEntity)
        {
            throw new NotImplementedException();
        }

        public ICollection<AuthorCreateResponseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AuthorCreateResponseModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AuthorCreateResponseModel Update(Author TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
