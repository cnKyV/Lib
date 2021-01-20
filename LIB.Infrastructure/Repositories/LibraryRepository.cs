using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        ILogger<Library> _logger;
        LibDBContext _libDbContext;
        public LibraryRepository(ILogger<Library> logger, LibDBContext libDbContext)
        {
            _logger = logger;
            _libDbContext = libDbContext;
        }
        public bool Clear()
        {
            try
            {
                _libDbContext.Libraries.RemoveRange(_libDbContext.Libraries);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;

            }
            _logger.LogInformation($"Libraries have been wiped out succesfully by {Environment.UserName} / {Environment.UserDomainName}");
            return true;
        }

        public Library Create(Library library)
        {
            try
            {
                _libDbContext.Libraries.Add(library);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            return library;
        }

        public bool DeleteById(int id)
        {
            var result = _libDbContext.Libraries.FirstOrDefault(i => i.Id == id);
            try
            {
                _libDbContext.Libraries.Remove(result);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            _logger.LogInformation($"Library with {id} ID has been removed succesfully by {Environment.UserName} / {Environment.UserDomainName}");
            return true;
        }

        public ICollection<Library> GetAll()
        {
            try
            {
                return _libDbContext.Libraries.ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public Library GetById(int id)
        {
            var result = _libDbContext.Libraries.FirstOrDefault(i => i.Id == id);
            try
            {
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public Library Update(Library library)
        {
            var result = _libDbContext.Libraries.FirstOrDefault(i => i.Id == library.Id);

            result.Name = library.Name;
            result.Contact = library.Contact;
            result.Books = library.Books;
            
            try
            {
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            return result;
        }
    }
}
