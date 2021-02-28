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
                AuthorBook authorBook = new AuthorBook();
                authorBook.Author = author;
                result.Authors.Add(authorBook);
            }
            foreach (var editor in qEditors)
            {
                BookEditor bookEditor = new BookEditor();
                bookEditor.Editor = editor;
                result.Editors.Add(bookEditor);
            }

            foreach (var genre in qGenres)
            {
                BookGenre bookGenre = new BookGenre();
                bookGenre.Genre = genre;
                result.Genres.Add(bookGenre);
            }

            foreach (var publisher in qPublishers)
            {
                BookPublisher bookPublisher = new BookPublisher();
                bookPublisher.Publisher = publisher;
                result.Publishers.Add(bookPublisher);
            }

            _bookService.Create(result);
            
            
           return _mapper.Map<BookResponseModel>(result);
        }

        public BookResponseModel UpdateRequest(BookUpdateModel book)
        {
            var result = _mapper.Map<Book>(book);
            var qAuthors = _authorService.GetMultipleByIds(book.Authors);
            var qEditors = _editorService.GetMultipleByIds(book.Editors);
            var qGenres= _genreService.GetMultipleByIds(book.Genres);
            var qPublishers= _publisherService.GetMultipleByIds(book.Publishers);

            foreach (var author in qAuthors)
            {
                AuthorBook authorBook = new AuthorBook();
                authorBook.Author = author;
                result.Authors.Add(authorBook);
            }
            foreach (var editor in qEditors)
            {
                BookEditor bookEditor = new BookEditor();
                bookEditor.Editor = editor;
                result.Editors.Add(bookEditor);
            }

            foreach (var genre in qGenres)
            {
                BookGenre bookGenre = new BookGenre();
                bookGenre.Genre = genre;
                result.Genres.Add(bookGenre);
            }

            foreach (var publisher in qPublishers)
            {
                BookPublisher bookPublisher = new BookPublisher();
                bookPublisher.Publisher = publisher;
                result.Publishers.Add(bookPublisher);
            }
            _bookService.Update(result);
            return _mapper.Map<BookResponseModel>(result);
        }

        public BookResponseModel BookView(int id)
        {
            return _mapper.Map<BookResponseModel>(_bookService.GetById(id));
        }
        
        public bool DeleteById(int id)
        {
            return _authorService.DeleteById(id);
        }

        public IEnumerable<BookResponseModel> BookViewMultiple()
        {
            return _mapper.Map<IEnumerable<BookResponseModel>>(_bookService.GetAll());
            //_mapper.Map<>()
        }
        
    }
}