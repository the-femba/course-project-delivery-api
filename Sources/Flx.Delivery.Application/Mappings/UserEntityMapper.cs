using AutoMapper;
using Flx.Delivery.Domain.Entities;
using Flx.Delivery.Domain.Enums;

namespace Flx.Delivery.Application.Mappings
{
    internal sealed class UserEntityMapper : Profile
    {
        public UserEntityMapper()
        {
            CreateMap<Microservices.Commands.RegistrateUserCommand.Command, UserEntity>()
                .ForMember(dest => dest.PasswordHash,
                    opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.Roles,
                    opts => opts.MapFrom(src => new RoleType[] { RoleType.User }));

            CreateMap<UserEntity, Microservices.Queries.GetCurrentUserInformationQuery.Result>();
        }
    }
}
