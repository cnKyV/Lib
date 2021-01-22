using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Domain.Requests
{
    public class AuthorRequest
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
        public ICreateModel CreateRequest(Author author)
        {
            var query = _mapper.Map<Author>(author);
            foreach (var authorbook in author.Books)
            {
                var moq = new AuthorBook();        
                query.Books.Add(moq);
            }
            var result = _mapper.Map<AuthorResponseModel>(_authorService.Create(query));

            return new AuthorCreateModel();
        }

        public IUpdateModel UpdateRequest()
        {
            throw new NotImplementedException();
        }
    }
}

