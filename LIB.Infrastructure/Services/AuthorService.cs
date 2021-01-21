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
       
        private readonly ILogger<AuthorService> _logger;
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(ILogger<AuthorService> logger, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        public Author Create(Author author)
        {
            var query = _authorRepository.Create(author);
            return query;
        }

        public ICollection<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public Author GetById(int Id)
        {
            var author = _authorRepository.GetById(Id);
            if (author == null)
            {
                _logger.LogInformation($"Unable to find author with Id: {Id}");
                return null;
            }
            _logger.LogInformation($"Succesfully returned author with Id: {author.Id}");
            return author; //can be mapped to domain here with a function such as MapDtoToDomain(author); --Dto = data table object = entity
        }


        public Author Update(Author author)
        {
            return _authorRepository.Update(author);
        }

        
    }
}
