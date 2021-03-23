using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Flx.ProjectName.Application.Interfaces.Services;
using MediatR;

namespace Flx.ProjectName.Application.Fork.Commands
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
