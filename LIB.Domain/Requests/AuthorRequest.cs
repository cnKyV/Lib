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
            foreach (var authorbook in author.Books)
            {
                var moq = new AuthorBook();
                moq.Book = _bookService.GetById(authorbook);
                query.Books.Add(moq);
            }
            _authorService.Create(query);
            var response = _mapper.Map<AuthorResponseModel>(query);
            foreach (var books in query.Books)
            {
                response.Books.Add(books.Book.Id);
            }
            try
            {
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }


        }
        public AuthorResponseModel UpdateRequest(AuthorUpdateModel author)
        {
            var query = _mapper.Map<Author>(author);
            foreach (var BookId in author.Books)
            {
                var moq = new AuthorBook();
                moq.Book = _bookService.GetById(BookId);
                query.Books.Add(moq);
            }
            var dbAuthor = _authorService.GetById(author.Id);

            dbAuthor.Name = query.Name;
            dbAuthor.Surname = query.Surname;
            dbAuthor.About = query.About;
            dbAuthor.DateOfBirth = query.DateOfBirth;
            dbAuthor.Books = query.Books;


            throw new NotImplementedException();
        }
    }
}

