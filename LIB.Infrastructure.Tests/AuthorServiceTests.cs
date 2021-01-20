using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
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
        public void Create_ShouldReturnAuthor_WhenAuthorExists()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
