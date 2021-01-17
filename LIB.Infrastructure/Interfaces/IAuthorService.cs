using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IAuthorService
    {
        ICollection<Author> GetAll();
        Author GetById(int id);
        Author Create(Author author);
        Author Update(Author author);
        bool Clear();
        bool DeleteById(int id);
    }
}
