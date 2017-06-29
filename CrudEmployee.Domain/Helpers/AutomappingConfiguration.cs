using FluentNHibernate.Automapping;
using System;
using CrudEmployee.Domain.Abstract;

namespace CrudEmployee.Domain.Helpers
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterface(typeof(IEntity).FullName) != null;
        }
    }
}
