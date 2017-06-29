
using CrudEmployee.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CrudEmployee.Domain.MappingOverrides
{
    public class CityOverrides : IAutoMappingOverride<City>
    {
        public void Override(AutoMapping<City> mapping)
        {
        }
    }
}
