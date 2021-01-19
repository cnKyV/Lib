using LIB.Contracts.Shared;
using System.Collections.Generic;

namespace LIB.Infrastructure.Interfaces
{
   public interface IService<T,Tview,Tcreate,Tupdate> where Tcreate : ICreateModel 
                                                      where Tupdate : IUpdateModel
    {
        ICollection<Tview> GetAll();
        Tview GetById(int Id);
        Tcreate Create(T Repository);
        Tupdate Update(T Repository);
    }
}
