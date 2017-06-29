using FluentNHibernate.Mapping;

namespace CrudEmployee.Domain.Entities.Mapping
{
    class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.Employess).Inverse();
            HasMany(x => x.Cities).Inverse();
        }
    }
}
