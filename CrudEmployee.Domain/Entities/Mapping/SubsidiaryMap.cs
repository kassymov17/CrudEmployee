using System.Security.Cryptography.X509Certificates;
using FluentNHibernate.Mapping;

namespace CrudEmployee.Domain.Entities.Mapping
{
    class SubsidiaryMap : ClassMap<Subsidiary>
    {
        public SubsidiaryMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasManyToMany(x => x.Organizations)
                .Cascade.All()
                .Inverse().Table("Organization_Subsidiary");
            HasMany(x => x.ChildSubsidiaries).KeyColumn("ParentSubsidiaryId");
            References(x => x.ParentSubsidiary).Column("ParentSubsidiaryId");
        }
    }
}
