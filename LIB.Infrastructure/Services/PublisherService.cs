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
        public ICreateModel Create(PublisherRepository Repository)
        {
            throw new NotImplementedException();
        }

        public ICollection<PublisherViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PublisherViewModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IUpdateModel Update(PublisherRepository Repository)
        {
            throw new NotImplementedException();
        }
    }
}
