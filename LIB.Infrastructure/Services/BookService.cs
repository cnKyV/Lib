using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly BookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;
        public BookService(BookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public Book Create(Book author)
        {
            throw new NotImplementedException();
        }

        public ICollection<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Book GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Book Update(Book author)
        {
            throw new NotImplementedException();
        }
    }
}
