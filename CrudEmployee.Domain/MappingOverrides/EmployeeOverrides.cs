
using CrudEmployee.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CrudEmployee.Domain.MappingOverrides
{
    public class EmployeeOverrides : IAutoMappingOverride<Employee>
    {
        public void Override(AutoMapping<Employee> mapping)
        {
        }
    }
}
