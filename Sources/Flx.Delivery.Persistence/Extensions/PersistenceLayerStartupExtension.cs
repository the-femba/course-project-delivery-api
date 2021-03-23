using System;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Persistence.Repositories;
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

            services.InitRepositories();
        }

        private static void InitRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IUserEntityStorage, UserEntityStorage>();
        }
    }
}
