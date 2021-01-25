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
using System.Collections.ObjectModel;
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
            _authorRepository.SaveChanges();
            return query;
        }

        public IEnumerable<Author> GetAll()
        
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

        public bool DeleteById(int id)
        {
            bool result = _authorRepository.DeleteById(id);
            _authorRepository.SaveChanges();
            return result;
        }

        public IEnumerable<Author> GetMultipleByIds(IEnumerable<int> ids)
        {
            return _authorRepository.GetMultipleById(ids);
        }

        public void SaveChanges()
        {
            _authorRepository.SaveChanges();
        }


        public Author Update(Author author)
        {
            return _authorRepository.Update(author);
        }

        public bool Clear()
        {
            bool result = _authorRepository.Clear();
            _authorRepository.SaveChanges();
            return result;
        }
    }
}
