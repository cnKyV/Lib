using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    interface IAuthorRepository
    {
        ICollection<Author> GetAll();
        Author GetById(int id);
        Author Create(Author TEntity);
        Author Update(Author TEntity);
        bool Clear();
        bool DeleteById(int id);
    }
}
