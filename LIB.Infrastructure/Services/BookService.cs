using LIB.Contracts.ResponseModel;
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
        public BookCreateResponseModel Create(BookRepository Repository)
        {
            throw new NotImplementedException();
        }

        public ICollection<BookCreateResponseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookCreateResponseModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public BookCreateResponseModel Update(BookRepository Repository)
        {
            throw new NotImplementedException();
        }
    }
}
