using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>
    {
        public PublisherRepository(ILogger<Publisher> logger, LibDBContext libDBContext) : base(logger, libDBContext)
        {

        }
    }
}
