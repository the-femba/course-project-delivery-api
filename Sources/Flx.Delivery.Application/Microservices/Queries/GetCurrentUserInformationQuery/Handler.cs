using AutoMapper;
using Flx.Delivery.Application.Interfaces.Accessors;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetCurrentUserInformationQuery
{
    public sealed class Handler : IRequestHandler<Query, Result>
    {
        private readonly IUserEntityStorage _userEntityStorage;
        private readonly IHttpAuthAccessor _authAccessor;
        private readonly IMapper _mapper;

        public Handler(IMapper mapper, IHttpAuthAccessor authAccessor, IUserEntityStorage userEntityStorage)
        {
            _userEntityStorage = userEntityStorage;
            _authAccessor = authAccessor;
            _mapper = mapper;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            string token = _authAccessor.AccessToken!;

            UserEntity user = (await _userEntityStorage.PickViaAccessToken(token))!;

            return _mapper.Map<Result>(user);
        }
    }
}
