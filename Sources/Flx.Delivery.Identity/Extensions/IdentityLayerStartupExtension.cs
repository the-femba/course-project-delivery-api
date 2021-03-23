using System;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using Flx.Delivery.Application.Interfaces.Accessors;
using Flx.Delivery.Identity.Accessors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rovecode.Lotos.Extensions;

namespace Flx.Delivery.Identity.Extensions
{
    public static class IdentityLayerStartupExtension
    {
        public static void AddIdentityLayer(this IServiceCollection services)
        {
            var currentAssembly = typeof(IdentityLayerStartupExtension).Assembly;

            services.AddLotos(currentAssembly);

            services.InitAccessort();
        }

        private static void InitAccessort(this IServiceCollection services)
        {
            services.AddSingleton<IHttpAuthAccessor, HttpAuthAccessor>();
        }
    }
}
