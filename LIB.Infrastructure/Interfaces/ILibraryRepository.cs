using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface ILibraryRepository
    {
        ICollection<Library> GetAll();
        Library GetById(int id);
        Library Create(Library library);
        Library Update(Library library);
        bool Clear();
        bool DeleteById(int id);
        void SaveChanges();
    }
}
