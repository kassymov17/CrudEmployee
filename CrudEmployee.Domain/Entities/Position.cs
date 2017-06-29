using CrudEmployee.Domain.Abstract;
using System.Collections.Generic;

namespace CrudEmployee.Domain.Entities
{
    public class Position : IEntity
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
    }
}
