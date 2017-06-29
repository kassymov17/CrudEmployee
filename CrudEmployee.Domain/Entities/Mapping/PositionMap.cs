using FluentNHibernate.Mapping;

namespace CrudEmployee.Domain.Entities.Mapping
{
    public class PositionMap : ClassMap<Position>
    {
        public PositionMap()
        {
            Id(x => x.Id);
            Map(x=>x.Name);
            HasMany(x => x.Employess).Inverse();
        }
    }
}
