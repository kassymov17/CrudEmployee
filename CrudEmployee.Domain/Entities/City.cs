using CrudEmployee.Domain.Abstract;
using System.Collections.Generic;

namespace CrudEmployee.Domain.Entities
{
    public class City : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Country Country { get; set; }
        private IList<Employee> _employees { get; set; }
        public virtual IList<Employee> Employees
        {
            get
            {
                return _employees ?? (_employees = new List<Employee>());
            }
            set { _employees = value; }
        }
    }
}
