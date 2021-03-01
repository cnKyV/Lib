using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LIB.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;
        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public Book Create(Book book)
        {
            var query = _bookRepository.Create(book);

            if (query == null)
            {
                _logger.LogInformation($"Book with Id: {book.Id} is not found.");
                return null;
            }
            _bookRepository.SaveChanges();
            _logger.LogInformation($"Book with Id: {query.Id} has been succesfully created.");
            return query;
            
            
            
        }

        public ICollection<Book> GetAll()
        {
            var result = _bookRepository.GetAll();
            if (result == null)
            {
                _logger.LogInformation($"Couldn't find any book in the database");
                return null;
            }
            return result;
        }

        public Book GetById(int Id)
        {
            var result = _bookRepository.GetById(Id);
            if (result == null)
            {
                _logger.LogInformation($"Couldn't find a book with Id: {Id}");
                return null;
            }
            
            return result;
        }

        public Book Update(Book book)
        {
            var result = _bookRepository.Update(book);
            if (result == null)
            {
                _logger.LogInformation($"Couldn't find a book with Id: {book.Id}");
                return null;
            }
            _bookRepository.SaveChanges();
            _logger.LogInformation($"Book with Id: {result.Id} has been succesfully updated.");
            return result;
        }

        public IEnumerable<Book> GetMultipleByIds(IEnumerable<int> ids)
        {
            return _bookRepository.GetMultipleById(ids);
        }
        

        public bool DeleteById(int id)
        {
            bool result = _bookRepository.DeleteById(id);
            _bookRepository.SaveChanges();
            return result;
        }
    }
}
