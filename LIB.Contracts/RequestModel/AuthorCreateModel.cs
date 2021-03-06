﻿using LIB.Contracts.Shared;
using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Contracts.RequestModel
{
    public class AuthorCreateModel : ICreateModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<int> Books { get; set; }
        //Contact
        public ContactCreateModel Contact { get; set; }

    }
}
