using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Flx.ProjectName.Application.Interfaces.Repositories;
using Flx.ProjectName.Domain.Enums;
using MediatR;

namespace Flx.ProjectName.Application.Fork.Queries
{
    public static class GetAllOldEntitiesQuery
    {
        public sealed class Query : IRequest<IEnumerable<Response>>
        {

        }

        public sealed class Response
        {
            public string Name { get; set; } = null!;
            public DateTime CreateDate { get; set; }
        }

        public sealed class Handler : IRequestHandler<Query, IEnumerable<Response>>
        {
            private readonly IMapper _mapper;
            private readonly IExampleEntityStorage _exampleStorage;

            public Handler(IMapper mapper, IExampleEntityStorage exampleStorage)
            {
                _mapper = mapper;
                _exampleStorage = exampleStorage;
            }

            public async Task<IEnumerable<Response>> Handle(Query request, CancellationToken cancellationToken)
            {
                var entities = await _exampleStorage.PickManyWithType(ExampleType.New);

                var responces = new List<Response>();

                foreach (var entity in entities)
                {
                    var response = _mapper.Map<Response>(entity);

                    responces.Add(response);
                }

                return responces;
            }
        }
    }
}
