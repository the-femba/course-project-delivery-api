using System;
using System.Threading.Tasks;
using Flx.ProjectName.Application.Interfaces.Repositories;
using Flx.ProjectName.Application.Interfaces.Services;
using Flx.ProjectName.Domain.Entities;
using Flx.ProjectName.Domain.Enums;

namespace Flx.ProjectName.Persistence.Services
{
    public sealed class ExampleService : IExampleService
    {
        private readonly IExampleEntityStorage _exampleStorage;

        public ExampleService(IExampleEntityStorage exampleStorage)
        {
            _exampleStorage = exampleStorage;
        }

        public async Task ChangeAllNewToOld()
        {
            var exampleEntitiesWithNewType = await _exampleStorage.PickManyWithType(ExampleType.New);

            foreach (var exampleEntity in exampleEntitiesWithNewType)
            {
                exampleEntity.Type = ExampleType.Old;
                await exampleEntity.Push();
            }
        }
    }
}
