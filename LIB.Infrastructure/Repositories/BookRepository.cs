using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {

        public BookRepository(ILogger<Book> logger, LibDBContext libDBContext) : base(logger,libDBContext)
        {
            
        }

    }
}
