using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Services
{
    public class LibraryService : ILibraryService
    {
        public ICreateModel Create(LibraryRepository Repository)
        {
            throw new NotImplementedException();
        }

        public ICollection<LibraryViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public LibraryViewModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IUpdateModel Update(LibraryRepository Repository)
        {
            throw new NotImplementedException();
        }
    }
}
