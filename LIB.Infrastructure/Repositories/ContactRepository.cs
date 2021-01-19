using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        ILogger<Contact> _logger;
        LibDBContext _libDbContext;
        public ContactRepository(ILogger<Contact> logger, LibDBContext libDBContext)
        {
            _libDbContext = libDBContext;
            _logger = logger;
        }
        public bool Clear()
        {
            try
            {
                _libDbContext.Contacts.RemoveRange(_libDbContext.Contacts);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                return false;
            }
            _logger.LogInformation($"Contacts Succesfully Cleared by {Environment.UserDomainName} / {Environment.UserName}");
            return true;
        }

        public Contact Create(Contact contact)
        {
            try
            {
                _libDbContext.Contacts.Add(contact);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            _logger.LogInformation($"Contact with ID: {contact.Id} has been succesfully created.");
            return contact;
        }

        public bool DeleteById(int id)
        {
            var contact = _libDbContext.Contacts.FirstOrDefault(i => i.Id == id);
            try
            {
                _libDbContext.Contacts.Remove(contact);
                _libDbContext.SaveChanges();
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
            try
            {
                return _libDbContext.Contacts.ToArray();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                return null;
            }
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

        public Contact Update(Contact TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
