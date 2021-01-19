using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly ILogger<Book> _logger;
        private readonly LibDBContext _libDbContext;
        public BookRepository(ILogger<Book> logger, LibDBContext libDBContext)
        {
            _logger = logger;
            _libDbContext = libDBContext;
        }
        public bool Clear()
        {     
            try
            {
                _libDbContext.RemoveRange(_libDbContext.Books);
                _libDbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            _logger.LogInformation($"Authors Succesfully Cleared by {Environment.UserDomainName} / {Environment.UserName}");
            return true;
        }

        public Book Create(Book book)
        {
            try
            {
                _libDbContext.Books.Add(book);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return null;
            }
            _logger.LogInformation($"Book with ID: {book.Id} has been succesfully created.");
            return book;
        }

        public bool DeleteById(int id)
        {
            var query = _libDbContext.Books.FirstOrDefault(i => i.Id == id);
            try
            {
                _libDbContext.Remove(query);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            _logger.LogInformation($"Book with ID: {id} has been succesfully removed.");
            return true;
        }

        public ICollection<Book> GetAll()
        {
            var query = _libDbContext.Books.ToArray();
            try
            {
                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public Book GetById(int id)
        {
            var book = _libDbContext.Books.FirstOrDefault(i => i.Id == id);
            try
            {
                return book;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public Book Update(Book book)
        {
            var query = _libDbContext.Books.FirstOrDefault(i => i.Id == book.Id);
            query.Name = book.Name;
            query.Description = book.Description;
            query.Edition = book.Edition;
            try
            {
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            return query;
        }
    }
}
