using FluentNHibernate.Mapping;

namespace CrudEmployee.Domain.Entities.Mapping
{
    class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            References(x => x.Country).Cascade.SaveUpdate();
            HasMany(x => x.Employees).Inverse();
        }
    }
}
