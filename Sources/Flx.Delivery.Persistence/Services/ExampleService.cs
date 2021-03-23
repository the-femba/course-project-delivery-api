using System;
using System.Threading.Tasks;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Application.Interfaces.Services;
using Flx.Delivery.Domain.Entities;
using Flx.Delivery.Domain.Enums;

namespace Flx.Delivery.Persistence.Services
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
