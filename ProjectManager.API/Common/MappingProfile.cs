using AutoMapper;
using ProjectManager.API.Features.Agencies.Commands;
using ProjectManager.API.Features.Boards.Commands;
using ProjectManager.API.Features.Projects.Commands;
using ProjectManager.API.Models;

namespace ProjectManager.API.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAgencyCommand, Agency>();
        CreateMap<CreateProjectCommand, Project>();
        CreateMap<CreateBoardCommand, Board>();
    }
}