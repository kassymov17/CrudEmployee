using FluentNHibernate.Mapping;

namespace CrudEmployee.Domain.Entities.Mapping
{
    class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Patronymic);
            Map(x => x.Phone);
            Map(x => x.Email);
            Map(x => x.Image);
            Map(x => x.DateOfBirth);
            References(x => x.Department).Cascade.SaveUpdate();
        }
    }
}
