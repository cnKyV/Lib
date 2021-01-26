using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        ILogger<Publisher> _logger;
        LibDBContext _libDbContext;
        public PublisherRepository(ILogger<Publisher> logger, LibDBContext libDbContext)
        {
            _logger = logger;
            _libDbContext = libDbContext;
        }
        public bool Clear()
        {
            try
            {
                _libDbContext.Publishers.RemoveRange(_libDbContext.Publishers);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;

            }
            _logger.LogInformation($"Publishers have been wiped out succesfully by {Environment.UserName} / {Environment.UserDomainName}");
            return true;
        }

        public Publisher Create(Publisher publisher)
        {
            try
            {
                _libDbContext.Publishers.Add(publisher);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            return publisher;
        }

        public bool DeleteById(int id)
        {
            var result = _libDbContext.Publishers.FirstOrDefault(i => i.Id == id);
            try
            {
                _libDbContext.Publishers.Remove(result);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            _logger.LogInformation($"Publisher with {id} ID has been removed succesfully by {Environment.UserName} / {Environment.UserDomainName}");
            return true;
        }

        public IEnumerable<Publisher> GetMultipleByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public ICollection<Publisher> GetAll()
        {
            try
            {
                return _libDbContext.Publishers.ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public Publisher GetById(int id)
        {
            var result = _libDbContext.Publishers.FirstOrDefault(i => i.Id == id);
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

        public Publisher Update(Publisher publisher)
        {
            var result = _libDbContext.Publishers.FirstOrDefault(i => i.Id == publisher.Id);

            result.Name = publisher.Name;
            result.About = publisher.About;
            result.Contact = publisher.Contact;
            result.Books = publisher.Books;
            result.Editors = publisher.Editors;
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
