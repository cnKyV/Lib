using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Infrastructure.Repositories;

namespace LIB.Infrastructure.Interfaces
{
   public interface IEditorService : IService<EditorViewModel, ICreateModel,IUpdateModel>
    {

    }
}
