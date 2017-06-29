using FluentNHibernate.Mapping;

namespace CrudEmployee.Domain.Entities.Mapping
{
    class OrganizationMap : ClassMap<Organization>
    {
        public OrganizationMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.Departments).Inverse();
            HasManyToMany(x => x.Subsidiaries)
                .Cascade.SaveUpdate().Table("Organization_Subsidiary");
        }
    }
}
