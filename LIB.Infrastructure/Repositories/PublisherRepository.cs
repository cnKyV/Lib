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
            _libDbContext.Publishers.Add(publisher);
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
            return true;
        }

        public IEnumerable<Publisher> GetMultipleByIds(IEnumerable<int> ids)
        {
            return  _libDbContext.Publishers.Where(i => ids.Contains(i.Id)).Select(i=>i).ToList();
        }

        public void SaveChanges()
        {
            try
            {
             _libDbContext.SaveChanges();
            }
            catch (Exception e)
            { 
                _logger.LogError(e, e.Message);
            }
           
        }

        public ICollection<Publisher> GetAll()
        {
            return _libDbContext.Publishers.ToArray();
        }

        public Publisher GetById(int id)
        {
           return _libDbContext.Publishers.FirstOrDefault(i => i.Id == id);
        }

        public Publisher Update(Publisher publisher)
        {
            var result = _libDbContext.Publishers.FirstOrDefault(i => i.Id == publisher.Id);

            result.Name = publisher.Name;
            result.About = publisher.About;
            result.Contact = publisher.Contact;
            result.Books = publisher.Books;
            result.Editors = publisher.Editors;
            return result;
        }
    }
}
