﻿using LIB.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Contracts.RequestModel
{
    public class LibraryCreateRequestModel : ICreateModel
    {
        public string Name { get; set; }
        public ICollection<int> Books { get; set; }
        public int ContactId { get; set; }
    }
}
