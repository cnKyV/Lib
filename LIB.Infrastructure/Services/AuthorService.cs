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
       
        private readonly ILogger _logger;
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(ILogger logger, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        public Author Create(Author author)
        {
            return _authorRepository.Create(author);
        }

        public ICollection<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public Author GetById(int Id)
        {
            return _authorRepository.GetById(Id);
        }

        public Author Update(Author author)
        {
            return _authorRepository.Update(author);
        }
    }
}
