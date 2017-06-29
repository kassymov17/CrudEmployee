
using CrudEmployee.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CrudEmployee.Domain.MappingOverrides
{
    public class PositionOverrides : IAutoMappingOverride<Position>
    {
        public void Override(AutoMapping<Position> mapping)
        {
        }
    }
}
