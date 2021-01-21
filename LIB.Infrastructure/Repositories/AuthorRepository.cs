using Castle.Core.Logging;
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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibDBContext _libDbContext;
        private readonly ILogger<AuthorRepository> _logger;
        public AuthorRepository(LibDBContext libDbContext, ILogger<AuthorRepository> logger)
        {
            _libDbContext = libDbContext;
            _logger = logger;
        }
        public bool Clear()
        {
            try
            {
                _libDbContext.Authors.RemoveRange(_libDbContext.Authors);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            return true;
        }

        public Author Create(Author author)
        {
            try
            {
                _libDbContext.Authors.Add(author);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            return author;
        }

        public bool DeleteById(int id)
        {
            var author = _libDbContext.Authors.FirstOrDefault(i => i.Id == id);
            try
            {
                _libDbContext.Authors.Remove(author);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            return true;
        }

        public ICollection<Author> GetAll()
        {
            try
            {
                return _libDbContext.Authors.ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public Author GetById(int id)
        {
            try
            {
                return _libDbContext.Authors.FirstOrDefault(i => i.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            
        }

        public void SaveChanges()
        {
            try
            {
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            
        }

        public Author Update(Author author)
        {
            var _author = _libDbContext.Authors.FirstOrDefault(i => i.Id == author.Id);
            try
            {
                _author.Name = author.Name;
                _author.Surname = author.Surname;
                _author.About = author.About;
                _author.DateOfBirth = author.DateOfBirth;
                _author.Books = author.Books;
                _libDbContext.SaveChanges();     
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            return _author;
        }
    }
}
