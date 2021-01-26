﻿using LIB.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Contracts.ResponseModel
{
    public class BookResponseModel : ICreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public string PdfSource { get; set; }
        public string Edition { get; set; }
        public ICollection<int> Authors { get; set; }
        public ICollection<int> Editors { get; set; }
        public ICollection<int> Publishers { get; set; }
        public ICollection<int> Genres { get; set; }
    }
}
