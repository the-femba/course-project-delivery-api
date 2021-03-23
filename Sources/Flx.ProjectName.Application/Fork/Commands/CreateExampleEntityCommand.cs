using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Flx.ProjectName.Application.Exceptions;
using Flx.ProjectName.Application.Interfaces.Repositories;
using Flx.ProjectName.Application.Interfaces.Services;
using Flx.ProjectName.Domain.Entities;
using MediatR;

namespace Flx.ProjectName.Application.Fork.Commands
{
    public static class CreateExampleEntityCommand
    {
        public sealed class Command : IRequest
        {
            public string Name { get; set; } = null!;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(e => e.Name)
                    .NotNull()
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(10);
            }
        }

        public sealed class Handler : IRequestHandler<Command>
        {
            private readonly IMapper _mapper;
            private readonly IExampleEntityStorage _exampleStorage;

            public Handler(IMapper mapper, IExampleEntityStorage exampleStorage)
            {
                _mapper = mapper;
                _exampleStorage = exampleStorage;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _exampleStorage.Exists(e => e.ObjectName == request.Name))
                {
                    var entity = _mapper.Map<ExampleEntity>(request);

                    await _exampleStorage.Put(entity);
                }
                else throw new ProjectNameException($"Example entity with name {request.Name} is exists", 400);

                return new Unit();
            }
        }
    }
}
