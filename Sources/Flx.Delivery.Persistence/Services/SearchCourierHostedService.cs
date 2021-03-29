using Flx.Delivery.Application.Interfaces.Backgrounds;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Domain.Entities;
using Flx.Delivery.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rovecode.Lotos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Persistence.Services
{

    public sealed class SearchCourierHostedService : ISearchCourierHostedService
    {
        private Timer? _timer;
        private readonly ILogger<SearchCourierHostedService> _logger;
        private readonly IStorage<OrderEntity> _orderStorage;
        private readonly IUserEntityStorage _userStorage;

        public SearchCourierHostedService(ILogger<SearchCourierHostedService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;

            using (var scope = serviceScopeFactory.CreateScope())
            {
                _userStorage = scope.ServiceProvider.GetRequiredService<IUserEntityStorage>();
                _orderStorage = scope.ServiceProvider.GetRequiredService<IStorage<OrderEntity>>();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Courier search service running.");

            _timer = new Timer(async e => await DoRound(), null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public async Task DoRound()
        {
            _logger.LogInformation("Round started.");

            var searchCourierOrders = await _orderStorage.PickMany(e => e.Status == OrderStatus.SearchForCourier);

            if (searchCourierOrders.Count() == 0)
            {
                _logger.LogWarning("No orders.");
                return;
            }

            var couriers = (await _userStorage.PickMany(e => e.IsHasRole(RoleType.Courier))).ToList();

            foreach (var item in couriers)
            {
                var courierHasActualOrders = await _orderStorage.Exists(e => e.Status != OrderStatus.Done && e.Status != OrderStatus.Cancel);

                if (courierHasActualOrders)
                {
                    couriers.Remove(item);
                }
            }

            foreach (var item in searchCourierOrders)
            {
                if (couriers.Count == 0)
                {
                    foreach (var logItem in searchCourierOrders)
                    {
                        _logger.LogWarning($"For order with id {logItem.Id} no couriers at this round.");
                    }

                    break;
                }

                var currentCourier = couriers.First();

                item.CourierId = currentCourier.Id;
                item.Status = OrderStatus.СourierGoesToRestaurant;

                await item.Push();

                _logger.LogInformation($"Attach courier with id {currentCourier.Id} for order with id {item.Id}.");

                couriers.Remove(currentCourier);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogWarning("Courier search service is stoped.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
