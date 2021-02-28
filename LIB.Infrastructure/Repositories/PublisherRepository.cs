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
        LibDBContext _libDbContext;
        public PublisherRepository(LibDBContext libDbContext)
        {
            _libDbContext = libDbContext;
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
            _libDbContext.SaveChanges();

           
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
