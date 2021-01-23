using AutoMapper;
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
            CreateMap<Author, AuthorResponseModel>()
                .ForMember(model => model.Books, entity=> entity.MapFrom(i => new List<int>()));
            CreateMap<AuthorCreateModel,Author>()
                  .ForMember(entity => entity.Books, model => model.MapFrom(i => new List<AuthorBook>()))
            .ForMember(entity => entity.Contact, model => model.MapFrom(i => new Contact() {Email= i.Email,
                Website = i.Website, Number1 = i.Number1, Number2 = i.Number2, Address = i.Address, City = i.City,
                State = i.State, Country = i.Country }));
            //<model,entity> .ForMember(entity => entity.Books, model => model.MapFrom(i => new List<AuthorBook>()));
        }

    }
}
