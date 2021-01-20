using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IMapper mapper, ILogger logger, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _authorRepository = authorRepository;
        }
        public ICreateModel Create(ICreateModel RequestModel)
        {
            Author author = _mapper.Map<Author>(RequestModel);
            _authorRepository.Create(author);
            return _mapper.Map<AuthorCreateResponseModel>(author);
        }

        public ICollection<AuthorViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AuthorViewModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IUpdateModel Update(IUpdateModel Repository)
        {
            throw new NotImplementedException();
        }
    }
}
