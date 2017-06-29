using FluentNHibernate.Mapping;

namespace CrudEmployee.Domain.Entities.Mapping
{
    class DepartmentMap : ClassMap<Department>
    {
        public DepartmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            References(x => x.Organization).Cascade.SaveUpdate().Column("OrganizationId");
            HasMany(x => x.Employees).Inverse();
        }
    }
}
