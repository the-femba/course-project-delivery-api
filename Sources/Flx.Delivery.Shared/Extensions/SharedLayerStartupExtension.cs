using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Shared.Repositories;
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

            services.AddSingleton<IFileStorage, FileStorage>();
        }
    }
}
