using AutoMapper;
using Flx.Delivery.Domain.Entities;
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
                    opts => opts.MapFrom(src => src.Password));
        }
    }
}
