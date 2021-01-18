using LIB.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace LIB.Infrastructure.Tests
{
    public class AuthorRepositoryTests
    {
        private readonly ILogger<AuthorRepository> _logger;
        private readonly LibDBContext _libDbContext;
        public AuthorRepositoryTests(ILogger<AuthorRepository> logger, LibDBContext libDBContext)
        {
            _logger = logger;
            _libDbContext = libDBContext;
        }
        [Fact]
        public void CreateTest_True()
        {
            AuthorRepository authorRepository = new AuthorRepository(_libDbContext,_logger);
            
            
        }        
        [Fact]
        public void UpdateTest()
        {

        }        
        [Fact]
        public void ClearTest()
        {

        }        
        [Fact]
        public void DeleteByIdTest()
        {

        }

    }
}
