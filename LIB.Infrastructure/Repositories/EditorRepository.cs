using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class EditorRepository : BaseRepository<Editor>
    {
        public EditorRepository(ILogger<Editor> logger, LibDBContext libDBContext) : base(logger, libDBContext)
        {

        }
    }
}
