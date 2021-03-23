using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Flx.Delivery.Application.Interfaces.Services;
using MediatR;

namespace Flx.Delivery.Application.Microservices.Commands
{
    public static class ChangeAllExampleEntitiesToOldCommand
    {
        public sealed class Command : IRequest
        {

        }

        public sealed class Handler : IRequestHandler<Command>
        {
            private readonly IMapper _mapper;
            private readonly IExampleService _exampleService;

            public Handler(IMapper mapper, IExampleService exampleService)
            {
                _mapper = mapper;
                _exampleService = exampleService;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _exampleService.ChangeAllNewToOld();

                return new Unit();
            }
        }
    }
}
