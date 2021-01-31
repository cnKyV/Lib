using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using LIB.Domain.Requests;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Services;
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
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IBookService> _bookServiceMock = new Mock<IBookService>();

        public GenreRequestTests()
        {
            _greq = new GenreRequest(_genreServiceMock.Object, _mapperMock.Object, _bookServiceMock.Object);

        }
        [Fact]
        public void CreateRequest_ShouldReturnResponseModel()
        {
            //Arrange
            var id = 1;
            var genrelabel = "Fantasy";
            var bookIds = new List<int>{1,2,3};
            var book = new Book() { Id = 1};
            var bookGenre = new BookGenre() { Book = book};
            var books = new List<BookGenre>();
            books.Add(bookGenre);
            
            var genreResponseModel = new GenreResponseModel {Id = id, Name = genrelabel, Books = bookIds};
            var genreCreateModel = new GenreCreateModel {Name = genrelabel, Books = bookIds};
            var genre = new Genre {Id = id, Name = genrelabel, Books = books};

            _genreServiceMock.Setup(service => service.Create(genre)).Returns(genre);
            _mapperMock.Setup(mapper=>mapper.Map<Genre>(GenreCreateModel)).
            //Act

            var genreQuery = _greq.CreateRequest(genreCreateModel);

            //Assert
            Assert.Equal(genreQuery, genreResponseModel);

        }
    }
}