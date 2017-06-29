using System.Collections.Generic;
using CrudEmployee.Domain.Abstract;

namespace CrudEmployee.Domain.Entities
{
    public class Department : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        
        public virtual Organization Organization { get; set; }

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
