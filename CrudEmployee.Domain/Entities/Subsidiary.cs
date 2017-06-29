using System.Collections.Generic;
using CrudEmployee.Domain.Abstract;

namespace CrudEmployee.Domain.Entities
{
    public class Subsidiary : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        /// <summary>
        /// Организации
        /// </summary>
        private IList<Organization> _organizations { get; set; }

        public virtual IList<Organization> Organizations
        {
            get
            {
                return _organizations ?? (_organizations = new List<Organization>());
            }
            set { _organizations = value; }
        }
        /// <summary>
        /// Родитель филиал
        /// </summary>
        public virtual Subsidiary ParentSubsidiary { get; set; }

        private IList<Subsidiary> _childSubsidiaries { get; set; }

        /// <summary>
        /// Дочерние филиалы
        /// </summary>
        public virtual IList<Subsidiary> ChildSubsidiaries
        {
            get
            {
                return _childSubsidiaries ?? (_childSubsidiaries = new List<Subsidiary>());
            }
            set { _childSubsidiaries = value; }
        }
    }
}
