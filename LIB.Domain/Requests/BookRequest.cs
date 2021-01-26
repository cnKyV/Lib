using System.Collections.Generic;
using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using LIB.Domain.Interfaces;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LIB.Domain.Requests
{
    public class BookRequest : IBookRequest
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IEditorService _editorService;
        private readonly IPublisherService _publisherService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly ILogger<BookRequest> _logger;
        public BookRequest(IAuthorService authorService, IMapper mapper,IBookService bookService,
            IEditorService editorService, IPublisherService publisherService, IGenreService genreService, ILogger<BookRequest> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _authorService = authorService;
            _bookService = bookService;
            _editorService = editorService;
            _publisherService = publisherService;
            _genreService = genreService;
        }
        public BookResponseModel CreateRequest(BookCreateModel book)
        {
            var result = _mapper.Map<Book>(book);
            var qAuthors = _authorService.GetMultipleByIds(book.Authors);
            var qEditors = _editorService.GetMultipleByIds(book.Editors);
            var qGenres= _genreService.GetMultipleByIds(book.Genres);
            var qPublishers= _publisherService.GetMultipleByIds(book.Publishers);

            foreach (var author in qAuthors)
            {
                AuthorBook _authorBook = new AuthorBook();
                _authorBook.Author = author;
                result.Authors.Add(_authorBook);
            }
            foreach (var editor in qEditors)
            {
                BookEditor _bookEditor = new BookEditor();
                _bookEditor.Editor = editor;
                result.Editors.Add(_bookEditor);
            }

            foreach (var genre in qGenres)
            {
                BookGenre _bookGenre = new BookGenre();
                _bookGenre.Genre = genre;
                result.Genres.Add(_bookGenre);
            }

            foreach (var publisher in qPublishers)
            {
                BookPublisher _bookPublisher = new BookPublisher();
                
            }
            return null;
        }

        public BookResponseModel UpdateRequest(BookCreateModel book)
        {
            throw new System.NotImplementedException();
        }

        public BookResponseModel BookView(int id)
        {
            throw new System.NotImplementedException();
        }
        

        public bool Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            return _authorService.DeleteById(id);
        }

        public IEnumerable<BookResponseModel> BookViewMultiple()
        {
            throw new System.NotImplementedException();
        }
        
    }
}