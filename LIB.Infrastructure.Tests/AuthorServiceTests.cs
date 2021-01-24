using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xunit;

namespace LIB.Infrastructure.Tests
{
   public class AuthorServiceTests
    {
        private readonly AuthorService _sut;
        private readonly Mock<ILogger<AuthorService>> _loggerMock = new Mock<ILogger<AuthorService>>();
        private readonly Mock<IAuthorRepository> _authorRepoMock = new Mock<IAuthorRepository>();
        public AuthorServiceTests()
        {
            _sut = new AuthorService(_loggerMock.Object,_authorRepoMock.Object);
        }
        [Fact]
        public void GetById_ShouldReturnAuthor_WhenAuthorExists()
        {
            //Arrange
            int id = 1;
            var authorName = "Cenkay";
            var authorSurname = "Vergili";
            var authorDto = new Author
            {
                Id = id,
                Name = authorName,
                Surname = authorSurname

            };
            _authorRepoMock.Setup(x => x.GetById(id))
                .Returns(authorDto);
            //Act
            var customer = _sut.GetById(id);
            //Assert
            Assert.Equal(id, customer.Id);
            Assert.Equal(authorName, customer.Name);
            Assert.Equal(authorSurname, customer.Surname);
            Assert.Equal(authorName, customer.Name);
        }        
        [Fact]
        public void GetById_ShouldReturnNull_WhenAuthorDoesntExist()
        {
            //Arrange
            
            _authorRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(()=>null);
            //Act
            var customer = _sut.GetById(1);
            //Assert
            Assert.Null(customer);
        }
        [Fact]
        public void GetById_ShouldLogAppriprioteMessage_WhenCustomerExists()
        {
            //Arrange
            int id = 1;
            var authorName = "Cenkay";
            var authorSurname = "Vergili";
            var authorDto = new Author
            {
                Id = id,
                Name = authorName,
                Surname = authorSurname

            };
            _authorRepoMock.Setup(x => x.GetById(id))
                .Returns(authorDto);
            //Act
            var customer = _sut.GetById(id);
            //Assert
            _loggerMock.Verify(x => x.Log(
                It.Is<LogLevel>(l => l == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t)=> v.ToString() == $"Succesfully returned author with Id: {id}"),
                It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)
                ));

        }
        [Fact]
        public void GetMultipleId_ShouldReturnAll_WithMatchingId()
        {
            //Arrange
            Collection<int> authorIds = new Collection<int>();
            authorIds.Add(1);
            authorIds.Add(2);
            authorIds.Add(3);
            authorIds.Add(4);
            authorIds.Add(5);

            ICollection<Author> authors = new List<Author>();
            authors.Add(new Author() {Id = 1, Name = "Cenkay", Surname = "Vergili", About = "WORSERERER"});
            authors.Add(new Author() {Id = 2, Name = "Cenkay", Surname = "Vergili", About = "WORSE"});
            authors.Add(new Author() {Id = 3, Name = "Cenkay", Surname = "Vergili"});
            authors.Add(new Author() {Id = 4, Name = "Cenkay", Surname = "Vergili"});
            authors.Add(new Author() {Id = 5, Name = "Cenkay", Surname = "Vergili"});
            authors.Add(new Author() {Id = 6, Name = "Cenkay", Surname = "Vergili"});

            _authorRepoMock.Setup(i => i.GetMultipleById(authorIds))
                .Returns(authors.ToList());


            //Act
            var authrs = _sut.GetMultipleByIds(authorIds);
            //Assert
            var auth1 = authors.ToList().FirstOrDefault(i => i.Id == 1);
            var auth1expected = authors.ToList().FirstOrDefault(i => i.Id == 2);
            Assert.Equal(auth1, auth1expected);
        }
    }
}
