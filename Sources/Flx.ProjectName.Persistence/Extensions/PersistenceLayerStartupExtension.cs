using System;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using Flx.ProjectName.Application.Interfaces.Services;
using Flx.ProjectName.Persistence.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rovecode.Lotos.Extensions;

namespace Flx.ProjectName.Persistence.Extensions
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
