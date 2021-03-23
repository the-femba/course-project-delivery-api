using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flx.Delivery.Domain.Entities;
using Flx.Delivery.Domain.Enums;
using Rovecode.Lotos.Repositories;

namespace Flx.Delivery.Application.Interfaces.Repositories
{
    public interface IExampleEntityStorage : IStorage<ExampleEntity>
    {
        public Task<IEnumerable<ExampleEntity>> PickManyWithType(ExampleType exampleType);
    }
}
