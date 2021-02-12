using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LIB.Infrastructure.Services
{
    public class PublisherService : IPublisherService
    {
       
        private readonly IPublisherRepository _publisherRepository;
        private readonly ILogger<Publisher> _logger;
        public PublisherService(IPublisherRepository publisherRepository, ILogger<Publisher> logger)
        {
            _publisherRepository = publisherRepository;
            _logger = logger;
        }
        public Publisher Create(Publisher publisher)
        {
            if (publisher is null)
            {
                _logger.LogInformation($"Publisher with Id{publisher.Id} does not exist in the database.");
                return null;
            }
            _publisherRepository.Create(publisher);
            _publisherRepository.SaveChanges();
            return publisher;
        }

        public ICollection<Publisher> GetAll()
        {
            return _publisherRepository.GetAll();
        }

        public Publisher GetById(int Id)
        {
            return _publisherRepository.GetById(Id);
        }

        public Publisher Update(Publisher publisher)
        {
            if (publisher is null)
            {
                _logger.LogInformation($"Publisher with Id:{publisher.Id} does not exist in the database");
                return null;
            }
            _publisherRepository.Update(publisher);
            _publisherRepository.SaveChanges();
            return publisher;
        }

        public bool DeleteById(int id)
        {
            return _publisherRepository.DeleteById(id);
        }

        public IEnumerable<Publisher> GetMultipleByIds(IEnumerable<int> ids)
        {
            return _publisherRepository.GetMultipleByIds(ids);
        }
    }
}
