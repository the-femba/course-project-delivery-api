using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flx.ProjectName.Domain.Entities;
using Flx.ProjectName.Domain.Enums;
using Rovecode.Lotos.Repositories;

namespace Flx.ProjectName.Application.Interfaces.Repositories
{
    public interface IExampleEntityStorage : IStorage<ExampleEntity>
    {
        public Task<IEnumerable<ExampleEntity>> PickManyWithType(ExampleType exampleType);
    }
}
