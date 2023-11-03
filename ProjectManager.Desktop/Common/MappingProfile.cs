using AutoMapper;
using ProjectManager.Desktop.Models;

namespace ProjectManager.Desktop.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Agency, Agency>();
        CreateMap<Project, Project>();
        CreateMap<Board, Board>();
        CreateMap<Column, Column>();
    }
}