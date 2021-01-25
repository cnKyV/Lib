using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IAuthorService 
    {
        IEnumerable<Author> GetAll();
        Author GetById(int Id);
        Author Create(Author author);
        Author Update(Author author);
        bool Clear();
        bool DeleteById(int id);
        public IEnumerable<Author> GetMultipleByIds(IEnumerable<int> ids);
        public void SaveChanges();
    }
}
