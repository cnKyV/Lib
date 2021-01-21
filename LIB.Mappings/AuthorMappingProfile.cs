﻿using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Mapping
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, AuthorResponseModel>();
            CreateMap<AuthorCreateModel,Author>()
                  .ForMember(entity => entity.Books, model => model.MapFrom(i => new List<AuthorBook>()))
            .ForMember(entity => entity.Contact, model => model.MapFrom(i => new Contact()));
            //<model,entity> .ForMember(entity => entity.Books, model => model.MapFrom(i => new List<AuthorBook>()));
        }

    }
}
