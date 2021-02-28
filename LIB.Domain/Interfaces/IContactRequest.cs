using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;

namespace LIB.Domain.Interfaces
{
    public interface IContactRequest
    {
        ContactResponseModel Update(ContactUpdateModel contactUpdateModel);
    }
}