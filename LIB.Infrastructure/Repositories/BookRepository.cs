using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return null;
            }
            return book;
        }

        public bool DeleteById(int id)
        {
            var query = _libDbContext.Books.Include(i=>i.Authors).Include(i=>i.Editors).
                Include(i=>i.Genres).Include(i=>i.Publishers).FirstOrDefault(i => i.Id == id);
            
            try
            {
                _libDbContext.Remove(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            return true;
        }

        public IEnumerable<Book> GetMultipleById(IEnumerable<int> ids)
        {
            return  _libDbContext.Books.Include(i=>i.Authors).Include(i=>i.Editors).
                Include(i=>i.Genres).Include(i=>i.Publishers).Where(i => ids.Contains(i.Id)).Select(i=>i).ToList();
        }

        public void SaveChanges()
        {
            try
            {
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
            }
        }

        public ICollection<Book> GetAll()
        {
            var query = _libDbContext.Books.Include(i=>i.Authors).Include(i=>i.Editors).
                Include(i=>i.Genres).Include(i=>i.Publishers).ToArray();
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
            var book = _libDbContext.Books.Include(i=>i.Authors).Include(i=>i.Editors).
                Include(i=>i.Genres).Include(i=>i.Publishers).FirstOrDefault(i => i.Id == id);
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
            var query = _libDbContext.Books.Include(i=>i.Authors).Include(i=>i.Editors).
                Include(i=>i.Genres).Include(i=>i.Publishers).FirstOrDefault(i => i.Id == book.Id);
            query.Name = book.Name;
            query.Description = book.Description;
            query.Edition = book.Edition;
            query.Pages = book.Pages;
            query.PdfSource = book.PdfSource;
            query.Authors = book.Authors;
            query.Editors = book.Editors;
            query.Genres = book.Genres;
            query.Publishers = book.Publishers;
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
