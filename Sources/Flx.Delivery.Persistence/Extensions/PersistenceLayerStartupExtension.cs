using System;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using Flx.Delivery.Application.Interfaces.Services;
using Flx.Delivery.Persistence.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rovecode.Lotos.Extensions;

namespace Flx.Delivery.Persistence.Extensions
{
    public static class PersistenceLayerStartupExtension
    {
        public static void AddPersistenceLayer(this IServiceCollection services)
        {
            var currentAssembly = typeof(PersistenceLayerStartupExtension).Assembly;

            services.AddLotos(currentAssembly);

            services.InitServices();
        }

        private static void InitServices(this IServiceCollection services)
        {
            services.AddTransient<IExampleService, ExampleService>();
        }
    }
}
