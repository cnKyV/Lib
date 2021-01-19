using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IBookService : IService<BookRepository, BookViewModel, ICreateModel, IUpdateModel>
    {

    }
}
