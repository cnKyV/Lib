using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Services
{
    public class PublisherService : IPublisherService
    {
       
        private readonly IPublisherRepository _publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public Publisher Create(Publisher author)
        {
            throw new NotImplementedException();
        }

        public ICollection<Publisher> GetAll()
        {
            throw new NotImplementedException();
        }

        public Publisher GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Publisher Update(Publisher author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publisher> GetMultipleByIds(IEnumerable<int> ids)
        {
            return _publisherRepository.GetMultipleByIds(ids);
        }
    }
}
