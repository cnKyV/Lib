using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
   public interface IAuthorRepository
    {
        ICollection<Author> GetAll();
        Author GetById(int id);
        Author Create(Author TEntity);
        Author Update(Author TEntity);
        bool DeleteById(int id);
        public void SaveChanges();
        public IEnumerable<Author> GetMultipleById(IEnumerable<int> ids);
    }
}
