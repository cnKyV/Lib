using System.Net.Http.Headers;
using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using LIB.Domain.Interfaces;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace LIB.Domain.Requests
{
    public class ContactRequest : IContactRequest
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactRequest> _logger;
        private readonly IMapper _mapper;
        public ContactRequest(IContactService contactService, ILogger<ContactRequest> logger, IMapper mapper)
        {
            _contactService = contactService;
            _logger = logger;
            _mapper = mapper;
        }


        public ContactResponseModel Update(ContactUpdateModel contactUpdateModel)
        {
            var contact = _mapper.Map<Contact>(contactUpdateModel);
            _contactService.Update(contact);
            return _mapper.Map<ContactResponseModel>(contact);
        }
    }
}