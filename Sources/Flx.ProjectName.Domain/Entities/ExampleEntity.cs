using System;
using Flx.ProjectName.Domain.Enums;
using Rovecode.Lotos.Entities;

namespace Flx.ProjectName.Domain.Entities
{
    public sealed class ExampleEntity : StorageEntity<ExampleEntity>
    {
        public string ObjectName { get; set; } = null!;

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public ExampleType Type { get; set; } = ExampleType.New;
    }
}
