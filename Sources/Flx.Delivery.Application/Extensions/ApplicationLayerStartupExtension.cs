using FluentValidation;
using Flx.Delivery.Application.Pipelines;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rovecode.Lotos.Extensions;
using System.Threading.Tasks;

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
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MicroserviceAutoLoggerPipeline<,>));
        }
    }
}
