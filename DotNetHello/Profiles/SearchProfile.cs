using System;
using AutoMapper;
using DotNetHello.Core.DTOs;
using DotNetHello.Core.Entities;

namespace DotNetHello.Profiles
{
    public class SearchProfile : Profile
    {
        public SearchProfile()
        {
            CreateMap<Search, SearchDto>().ReverseMap();
        }
    }
}
