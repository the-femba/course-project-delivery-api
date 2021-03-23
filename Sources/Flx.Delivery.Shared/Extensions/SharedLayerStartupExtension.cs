using System;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rovecode.Lotos.Extensions;

namespace Flx.Delivery.Identity.Extensions
{
    public static class SharedLayerStartupExtension
    {
        public static void AddSharedLayer(this IServiceCollection services)
        {
            var currentAssembly = typeof(SharedLayerStartupExtension).Assembly;

            services.AddLotos(currentAssembly);
        }
    }
}
