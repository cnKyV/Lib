using LIB.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using LIB.Core.Entities;

namespace LIB.Contracts.ResponseModel
{
    public class EditorResponseModel : ICreateModel
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<BookEditorResponseModel> Books { get; set; }
        public ICollection<EditorPublisherResponseModel> Publishers { get; set; }
        public int ContactId { get; set; }
    }
}
