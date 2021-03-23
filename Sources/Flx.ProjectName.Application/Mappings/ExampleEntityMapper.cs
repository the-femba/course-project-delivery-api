using System;
using AutoMapper;
using Flx.ProjectName.Application.Fork.Commands;
using Flx.ProjectName.Application.Fork.Queries;
using Flx.ProjectName.Domain.Entities;

namespace Flx.ProjectName.Application.Mappings
{
    public class ExampleEntityMapper : Profile
    {
        public ExampleEntityMapper()
        {
            CreateMap<CreateExampleEntityCommand.Command, ExampleEntity>()
                .ForMember(dest => dest.ObjectName,
                    opts => opts.MapFrom(src => src.Name));
            CreateMap<ExampleEntity, GetAllOldEntitiesQuery.Response>()
                .ForMember(dest => dest.Name,
                    opts => opts.MapFrom(src => src.ObjectName));
        }
    }
}
