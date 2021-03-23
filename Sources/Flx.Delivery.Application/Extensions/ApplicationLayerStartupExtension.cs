using System;
using System.Reflection;
using AutoMapper;
using Flx.Delivery.Application.Pipelines;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rovecode.Lotos.Extensions;

namespace Flx.Delivery.Application.Extensions
{
    public static class ApplicationLayerStartupExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            var currentAssembly = typeof(ApplicationLayerStartupExtension).Assembly;

            services.AddLotos(currentAssembly);

            services.AddAutoMapper(currentAssembly);

            services.AddValidatorsFromAssembly(currentAssembly);

            services.AddMediatR(currentAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));
        }
    }
}
