using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Application.Interfaces.Services;
using Flx.Delivery.Domain.Entities;
using Flx.Delivery.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rovecode.Lotos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Persistence.Services
{
    public sealed class InitAdminService : BackgroundService, IInitAdminService
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IUserEntityStorage _userStorage = null!;
        private IMediator _mediator = null!;

        public InitAdminService(IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
        {
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                _userStorage = scope.ServiceProvider.GetRequiredService<IUserEntityStorage>();

                await DoWork();
            }
        }

        private async Task DoWork()
        {
            var section = _configuration.GetSection("Delivery");

            if (section is null)
            {
                return;
            }

            var email = section["AdminEmail"];
            var password = section["AdminPassword"];

            if (email is null || password is null)
            {
                return;
            }

            var user = await _userStorage.Pick(e => e.Email == email);

            if (user is null)
            {
                var command = new Application.Microservices.Commands.RegistrateUserCommand.Command()
                {
                    FirstName = "admin",
                    LastName = "admin",
                    Email = email,
                    Password = password,
                };

                await _mediator.Send(command);

                var nuser = (await _userStorage.Pick(e => e.Email == email))!;
                (nuser.Roles as List<RoleType>)!.Add(RoleType.Admin);
                await nuser.Push();
            }
        }
    }
}
