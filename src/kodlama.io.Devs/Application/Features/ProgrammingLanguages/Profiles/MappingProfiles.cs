﻿using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        { 
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
        }
    }
}
