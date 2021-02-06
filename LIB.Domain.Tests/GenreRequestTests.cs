using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Common;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using LIB.Domain.Requests;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Services;
using LIB.Mapping;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using ILogger = Serilog.ILogger;

namespace LIB.Domain.Tests
{
    public class GenreRequestTests
    {
        private readonly GenreRequest _greq;
        private readonly Mock<IGenreService> _genreServiceMock = new Mock<IGenreService>();
        private readonly Mock<IBookService> _bookServiceMock = new Mock<IBookService>();

        private MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });

        public GenreRequestTests()
        {
            var _mapperMock = cfg.CreateMapper();
            

            _greq = new GenreRequest(_genreServiceMock.Object, _mapperMock, _bookServiceMock.Object);

        }
        
        [Fact]
        public void CreateRequest_ShouldReturnResponseModel()
        {
            //Arrange
            var id = 0;
            var genrelabel = "Fantasy";
            var bookIds = new List<int>{1,2,3};
            var bookResponseModels = new List<BookGenreResponseModel>() {new BookGenreResponseModel(){BookId = 1},new BookGenreResponseModel(){BookId = 2},new BookGenreResponseModel(){BookId = 3} };
            var book = new Book() { Id = 1, Name = "FirstBook"};
            var bookGenre = new BookGenre() { Book = book};
            var books = new List<BookGenre>();
            books.Add(bookGenre);
            IEnumerable<Book> genres = new[] {new Book() {Id = 1}, new Book() {Id = 2}, new Book() {Id = 3}};
            
            var genreCreateModel = new GenreCreateModel {Name = genrelabel, Books = bookIds};
            var genre = new Genre {Id = id, Name = genrelabel, Books = books};
            _genreServiceMock.Setup(service => service.Create(genre)).Returns(genre);
            _bookServiceMock.Setup(service => service.GetMultipleByIds(It.IsAny<IEnumerable<int>>())).Returns(genres);
            
            // _mapperMock.Setup(m => m.Map<GenreCreateModel, Genre>(It.IsAny<GenreCreateModel>())).Returns(genre);
            // _mapperMock.Setup(m => m.Map<Genre, GenreResponseModel>(It.IsAny<Genre>())).Returns(genreResponseModel);
            
            //Act
            var genreResponseModel = new GenreResponseModel {Id = id, Name = genrelabel, Books = bookResponseModels};
            var genreQuery = _greq.CreateRequest(genreCreateModel);
            

            //Assert
            genreQuery.IsSameOrEqualTo(genreResponseModel);

        }
    }
}