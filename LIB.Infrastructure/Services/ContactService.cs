using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;


namespace LIB.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ILogger<IContactService> _logger;
        public ContactService(IContactRepository contactRepository, ILogger<IContactService> logger)
        {
            _contactRepository = contactRepository;
            _logger = logger;
        }
        public Contact Update(Contact contact)
        {
            var scontact = _contactRepository.Update(contact);
            if (scontact is null)
            {
                _logger.LogError($"Contact with ID: {scontact.Id} is null.");
                return null;
            }
            return scontact;
        }
    }
}
