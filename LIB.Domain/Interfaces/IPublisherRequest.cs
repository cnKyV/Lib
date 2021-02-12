using System.Collections.Generic;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;

namespace LIB.Domain.Interfaces
{
    public interface IPublisherRequest
    {
        IEnumerable<PublisherResponseModel> View();
        PublisherResponseModel View(int id);
        PublisherResponseModel Create(PublisherCreateModel createModel);
        PublisherResponseModel Update(PublisherUpdateModel updateModel);
        bool DeleteById(int id);
    }
}