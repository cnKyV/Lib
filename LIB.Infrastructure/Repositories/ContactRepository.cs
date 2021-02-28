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

        LibDBContext _libDbContext;
        public ContactRepository(LibDBContext libDBContext)
        {
            _libDbContext = libDBContext;
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
            return query;
        }
    }
}
