using Flx.Delivery.Application.Interfaces.Accessors;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Domain.Entities;
using MediatR;
using Rovecode.Lotos.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetUserOrderIdIfHasItQuery
{
    public sealed class Handler : IRequestHandler<Query, Result>
    {
        private readonly IStorage<OrderEntity> _orderStorage;
        private readonly IUserEntityStorage _userEntityStorage;
        private readonly IHttpAuthAccessor _authAccessor;

        public Handler(IHttpAuthAccessor authAccessor, IUserEntityStorage userEntityStorage, IStorage<OrderEntity> orderStorage)
        {
            _userEntityStorage = userEntityStorage;
            _orderStorage = orderStorage;
            _authAccessor = authAccessor;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            string token = _authAccessor.AccessToken!;
            UserEntity user = (await _userEntityStorage.PickViaAccessToken(token))!;

            var order = await _orderStorage.Pick(e => e.CustomerId == user.Id && e.Status >= 0);

            if (order is null)
            {
                return new();
            }

            return new()
            {
                OrderId = order.Id,
            };
        }
    }
}
