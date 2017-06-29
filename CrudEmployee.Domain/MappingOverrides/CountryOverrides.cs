
using CrudEmployee.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CrudEmployee.Domain.MappingOverrides
{
    public class CountryOverrides : IAutoMappingOverride<Country>
    {
        public void Override(AutoMapping<Country> mapping)
        {
        }
    }
}
