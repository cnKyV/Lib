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
    public interface IBookService 
    {
        ICollection<Book> GetAll();
        Book GetById(int Id);
        Book Create(Book author);
        Book Update(Book author);
        public IEnumerable<Book> GetMultipleByIds(IEnumerable<int> ids);
    }
}
