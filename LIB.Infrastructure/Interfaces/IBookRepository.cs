using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetAll();
        Book GetById(int id);
        Book Create(Book book);
        Book Update(Book book);
        bool Clear();
        bool DeleteById(int id);
        public ICollection<Book> GetMultipleById(ICollection<int> ids);
    }
}
