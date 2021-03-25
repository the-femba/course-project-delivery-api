using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flx.Delivery.Domain.Entities;
using static Flx.Delivery.Domain.Entities.RestaurantEntity;
using Flx.Delivery.Application.Models;

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
