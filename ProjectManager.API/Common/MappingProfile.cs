﻿using AutoMapper;
using ProjectManager.API.Features.Agencies.Commands;
using ProjectManager.API.Models;

namespace ProjectManager.API.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAgencyCommand, Agency>();
        }
    }
}