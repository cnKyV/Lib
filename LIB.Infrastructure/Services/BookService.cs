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
    public class BookService : IBookService
    {
        public ICreateModel Create(BookRepository Repository)
        {
            throw new NotImplementedException();
        }

        public ICollection<BookViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookViewModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IUpdateModel Update(BookRepository Repository)
        {
            throw new NotImplementedException();
        }
    }
}
