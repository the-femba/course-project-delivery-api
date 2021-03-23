using System;
using AutoMapper;
using Flx.Delivery.Application.Microservices.Commands;
using Flx.Delivery.Application.Microservices.Queries;
using Flx.Delivery.Domain.Entities;

namespace Flx.Delivery.Application.Mappings
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
