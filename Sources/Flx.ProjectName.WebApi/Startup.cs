using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flx.ProjectName.Application.Extensions;
using Flx.ProjectName.Identity.Extensions;
using Flx.ProjectName.Persistence.Extensions;
using Flx.ProjectName.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Rovecode.Lotos.Extensions;

namespace Flx.ProjectName.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // custom
            services.AddApplicationLayer();
            services.AddIdentityLayer();
            services.AddPersistenceLayer();
            services.AddSharedLayer();

            // auto
            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Flx.ProjectName.WebApi", Version = "v1" });
            });
            services.ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flx.ProjectName.WebApi v1"));
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
