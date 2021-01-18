using Castle.Core.Logging;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibDBContext _libDBContext;
        private readonly ILogger<AuthorRepository> _logger;
        public AuthorRepository(LibDBContext libDBContext, ILogger<AuthorRepository> logger)
        {
            _libDBContext = libDBContext;
            _logger = logger;
        }
        public bool Clear()
        {
            throw new NotImplementedException();
        }

        public Author Create(Author author)
        {
            try
            {
                _libDBContext.Authors.Add(author);
                _libDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            _logger.LogInformation($"Author with ID: {author.Id} has been succesfully created.");
            return author;
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Author Update(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
