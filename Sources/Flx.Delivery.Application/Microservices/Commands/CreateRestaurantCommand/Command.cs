using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Domain.Enums;
using MediatR;
using static Flx.Delivery.Domain.Entities.RestaurantEntity;

namespace Flx.Delivery.Application.Microservices.Commands.CreateRestaurantCommand
{
    [Auth(RoleType.Admin)]
    public sealed class Command : IRequest<Result>
    {
        public sealed class RestaurantPhotosData
        {
            public string LogoPhotoBase64 { get; set; } = null!;

            public string BackwardPhotoBase64 { get; set; } = null!;
        }

        public RestaurantInformation RestaurantInformation { get; set; } = new();

        public RestaurantPhotosData RestaurantPhotos { get; set; } = new();
    }
}
