using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        ILogger<Contact> _logger;
        LibDBContext _libDbContext;
        public ContactRepository(ILogger<Contact> logger, LibDBContext libDBContext)
        {
            _libDbContext = libDBContext;
            _logger = logger;
        }

        public Contact Create(Contact contact)
        {
            _libDbContext.Contacts.Add(contact);
                return contact;
        }

        public bool DeleteById(int id)
        {
            var contact = _libDbContext.Contacts.FirstOrDefault(i => i.Id == id);
            try
            {
                _libDbContext.Contacts.Remove(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            _logger.LogInformation($"Author with ID: {id} has been succesfully removed.");
            return true;
        }

        public ICollection<Contact> GetAll()
        {
            return _libDbContext.Contacts.ToArray();
        }

        public Contact GetById(int id)
        {
            try
            {
                return _libDbContext.Contacts.FirstOrDefault(i => i.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public Contact Update(Contact contact)
        {
            var query = _libDbContext.Contacts.FirstOrDefault(i => i.Id == contact.Id);
            query.Address = contact.Address;
            query.City = contact.City;
            query.Country = contact.Country;
            query.Email = contact.Email;
            query.Number1 = contact.Number1;
            query.Number2 = contact.Number2;
            query.State = contact.State;
            query.ZipCode= contact.ZipCode;
            query.Website= contact.Website;
            query.ZipCode = contact.ZipCode;
            try
            {
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            _logger.LogInformation($"Record with {query.Id} Id has been updated succesfully");
            return query;

        }
    }
}
