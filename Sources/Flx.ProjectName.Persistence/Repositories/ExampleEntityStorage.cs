using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flx.ProjectName.Application.Interfaces.Repositories;
using Flx.ProjectName.Domain.Entities;
using Flx.ProjectName.Domain.Enums;
using Rovecode.Lotos.Contexts;
using Rovecode.Lotos.Repositories;

namespace Flx.ProjectName.Persistence.Repositories
{
    public sealed class ExampleEntityStorage : Storage<ExampleEntity>, IExampleEntityStorage
    {
        public ExampleEntityStorage(StorageContext<ExampleEntity> storageContext) : base(storageContext)
        {

        }

        public Task<IEnumerable<ExampleEntity>> PickManyWithType(ExampleType exampleType)
        {
            return PickMany(e => e.Type == exampleType);
        }
    }
}
