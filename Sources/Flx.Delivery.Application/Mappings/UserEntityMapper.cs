using AutoMapper;
using Flx.Delivery.Domain.Entities;
using Flx.Delivery.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Mappings
{
    public sealed class UserEntityMapper : Profile
    {
        public UserEntityMapper()
        {
            CreateMap<Microservices.Commands.RegistrateUserCommand.Command, UserEntity>()
                .ForMember(dest => dest.PasswordHash,
                    opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.Roles,
                    opts => opts.MapFrom(src => new RoleType[] { RoleType.User }));
        }
    }
}
