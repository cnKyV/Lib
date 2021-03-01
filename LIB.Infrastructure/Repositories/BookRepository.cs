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
        private readonly LibDBContext _libDbContext;
        public BookRepository(LibDBContext libDBContext)
        {
            _libDbContext = libDBContext;
        }
        
        public Book Create(Book book)
        {
            _libDbContext.Books.Add(book);
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
                
                return false;
            }
            return true;
        }

        public IEnumerable<Book> GetMultipleById(IEnumerable<int> ids)
        {
            return  _libDbContext.Books.Include(i=>i.Authors).ThenInclude(i=>i.Author).Include(i=>i.Editors).ThenInclude(i=>i.Editor).
                Include(i=>i.Genres).ThenInclude(i=>i.Genre).Include(i=>i.Publishers).ThenInclude(i=>i.Publisher).Where(i => ids.Contains(i.Id)).Select(i=>i).ToList();
        }

        public void SaveChanges()
        {
            _libDbContext.SaveChanges();
        }

        public ICollection<Book> GetAll()
        {
            var query = _libDbContext.Books.Include(i=>i.Authors).ThenInclude(i=>i.Author).Include(i=>i.Editors).ThenInclude(i=>i.Editor).
                Include(i=>i.Genres).ThenInclude(i=>i.Genre).Include(i=>i.Publishers).ThenInclude(i=>i.Publisher).ToArray();
            return query;

        }

        public Book GetById(int id)
        {
            var book = _libDbContext.Books.Include(i=>i.Authors).ThenInclude(i=>i.Author).Include(i=>i.Editors).ThenInclude(i=>i.Editor).
                Include(i=>i.Genres).ThenInclude(i=>i.Genre).Include(i=>i.Publishers).ThenInclude(i=>i.Publisher).FirstOrDefault(i => i.Id == id);

                return book;
        }

        public Book Update(Book book)
        {
            var query = _libDbContext.Books.Include(i=>i.Authors).ThenInclude(i=>i.Author).Include(i=>i.Editors).ThenInclude(i=>i.Editor).
                Include(i=>i.Genres).ThenInclude(i=>i.Genre).Include(i=>i.Publishers).ThenInclude(i=>i.Publisher).FirstOrDefault(i => i.Id == book.Id);
            query.Name = book.Name;
            query.Description = book.Description;
            query.Edition = book.Edition;
            query.Pages = book.Pages;
            query.PdfSource = book.PdfSource;
            query.Authors = book.Authors;
            query.Editors = book.Editors;
            query.Genres = book.Genres;
            query.Publishers = book.Publishers;
            return query;
        }
        
    }
}
