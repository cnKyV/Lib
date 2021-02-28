using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Domain.Interfaces;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LIB.Domain.Requests
{
    public class AuthorRequest : IAuthorRequest
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly ILogger<AuthorRequest> _logger;
        private readonly IMapper _mapper;
        public AuthorRequest(IAuthorService authorService, IBookService bookService, ILogger<AuthorRequest> logger, IMapper mapper)
        {
            _authorService = authorService;
            _bookService = bookService;
            _logger = logger;
            _mapper = mapper;
        }
        public AuthorResponseModel CreateRequest(AuthorCreateModel author)
        {
            var query = _mapper.Map<Author>(author);
            var result = _bookService.GetMultipleByIds(author.Books);
           
            foreach (var ids in result)
            {
                var moq = new AuthorBook();
                moq.Book = ids;
                query.Books.Add(moq);
            }
            _authorService.Create(query);
            var response = _mapper.Map<AuthorResponseModel>(query);
            return response;
        }
        
        public AuthorResponseModel UpdateRequest(AuthorUpdateModel author)
        {
            var query = _mapper.Map<Author>(author);
            var result = _bookService.GetMultipleByIds(author.Books);
           
            foreach (var ids in result)
            {
                var moq = new AuthorBook();
                moq.Book = ids;
                query.Books.Add(moq);
            }
           var tbrAuthor = _authorService.Update(query);
            var model = _mapper.Map<AuthorResponseModel>(tbrAuthor);
            return model;
        }
        
        public AuthorResponseModel AuthorView(int id)
        {
            return _mapper.Map<AuthorResponseModel>(_authorService.GetById(id));
        }
        

        public bool DeleteById(int id)
        {
            return _authorService.DeleteById(id);
        }
        

        public IEnumerable<AuthorResponseModel> AuthourViewMultiple()
        {
            //var query = _authorService.GetAll();
            // foreach (var author in query)
            // {
            //     yield return _mapper.Map<AuthorResponseModel>(author);
            // }
            var result = _mapper.Map<IEnumerable<AuthorResponseModel>>(_authorService.GetAll());
            return result;
        }
        
        
    }
}

