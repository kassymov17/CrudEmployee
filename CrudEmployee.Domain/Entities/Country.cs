using CrudEmployee.Domain.Abstract;
using System.Collections.Generic;

namespace CrudEmployee.Domain.Entities
{
    public class Country : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        private IList<Employee> _employees;
        public virtual IList<Employee> Employess
        {
            get
            {
                return _employees ?? (_employees = new List<Employee>());
            }
            set { _employees = value; }
        }

        private IList<City> _cities;
        public virtual IList<City> Cities
        {
            get
            {
                return _cities ?? (_cities = new List<City>());
            }
            set { _cities = value; }
        }
    }
}
