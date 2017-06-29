using System.Collections.Generic;
using CrudEmployee.Domain.Abstract;

namespace CrudEmployee.Domain.Entities
{
    public class Organization : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        private IList<Subsidiary> _subsidiaries { get; set; }

        public virtual IList<Subsidiary> Subsidiaries
        {
            get
            {
                return _subsidiaries ?? (_subsidiaries = new List<Subsidiary>());
            }
            set { _subsidiaries = value; }
        }
        
        private IList<Department> _departments { get; set; }

        public virtual IList<Department> Departments
        {
            get
            {
                return _departments ?? (_departments = new List<Department>());
            }
            set { _departments = value; }
        }
    }
}
