using LIB.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Contracts.ResponseModel
{
    public class PublisherResponseModel : ICreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public ICollection<EditorPublisherResponseModel> Editors { get; set; }
        public ICollection<BookPublisherResponseModel> Books { get; set; }
        public int ContactId { get; set; }
    }
}
