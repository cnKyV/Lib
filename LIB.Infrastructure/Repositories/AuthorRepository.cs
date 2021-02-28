using Castle.Core.Logging;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LIB.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibDBContext _libDbContext;
        public AuthorRepository(LibDBContext libDbContext)
        {
            _libDbContext = libDbContext;
        }


        public Author Create(Author author)
        {
            _libDbContext.Authors.Add(author);
                return author;
        }

        public bool DeleteById(int id)
        {
            var author = _libDbContext.Authors.Include(i=>i.Books).FirstOrDefault(i => i.Id == id);
            try
            {
                _libDbContext.Authors.Remove(author);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public ICollection<Author> GetAll()
        {
            return _libDbContext.Authors.Include(i=>i.Books).ThenInclude(i=>i.Book).Include(i=>i.Contact).ToArray();
        }

        public Author GetById(int id)
        {
            return _libDbContext.Authors.Include(i=>i.Books).ThenInclude(i=>i.Book).Include(i=>i.Contact).FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Author> GetMultipleById(IEnumerable<int> ids)
        {
          return  _libDbContext.Authors.Where(i => ids.Contains(i.Id)).Select(i=>i).ToList();
        }

        public void SaveChanges()
        {
            _libDbContext.SaveChanges();
        }

        public Author Update(Author author)
        {
            var _author = _libDbContext.Authors.Include(i=>i.Books).ThenInclude(i=>i.Book).Include(i=>i.Contact).FirstOrDefault(i => i.Id == author.Id);
                _author.Name = author.Name;
                _author.Surname = author.Surname;
                _author.About = author.About;
                _author.DateOfBirth = author.DateOfBirth;
                _author.Books = author.Books;
                
                return _author;
        }
        
    }
}
