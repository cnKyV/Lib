using Microsoft.Extensions.Logging;
using LIB.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LIB.Infrastructure.Repositories
{
    public class BaseRepository<T>
    {
        ILogger<T> _logger;
        LibDBContext _libDbContext;
        public BaseRepository(ILogger<T> logger, LibDBContext libDBContext)
        {
            _logger = logger;
            _libDbContext = libDBContext;
 
        }
    }
}
