using System.Collections.Generic;
using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using LIB.Domain.Interfaces;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Services;

namespace LIB.Domain.Requests
{
    public class GenreRequest : IGenreRequest
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public GenreRequest(IGenreService genreService, IMapper mapper, IBookService bookService)
        {
            _genreService = genreService;
            _mapper = mapper;
            _bookService = bookService;
        }
        public GenreResponseModel CreateRequest(GenreCreateModel genre)
        {
           var mGenre = _mapper.Map<Genre>(genre);
           var books = _bookService.GetMultipleByIds(genre.Books);
           foreach (var book in books)
           {
               var moq = new BookGenre();
               moq.Book = book;
               mGenre.Books.Add(moq);
           }
           _genreService.Create(mGenre);
           
           return _mapper.Map<GenreResponseModel>(mGenre);
        }

        public GenreResponseModel UpdateRequest(GenreUpdateModel genre)
        {
            var mGenre = _mapper.Map<Genre>(genre);
            var books = _bookService.GetMultipleByIds(genre.Books);
            foreach (var book in books)
            {
                var moq = new BookGenre();
                moq.Book = book;
                mGenre.Books.Add(moq);
            }

            _genreService.Update(mGenre);

            return _mapper.Map<GenreResponseModel>(mGenre);

        }

        public GenreResponseModel GenreView(int id)
        {
            return _mapper.Map<GenreResponseModel>(_genreService.GetById(id));
        }        public IEnumerable<GenreResponseModel> GenreView()
        {
            return _mapper.Map<IEnumerable<GenreResponseModel>>(_genreService.GetAll());
        }

        public bool DeleteById(int id)
        {
            return _genreService.DeleteById(id);
        }
        
    }
}