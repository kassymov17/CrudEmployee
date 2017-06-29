using System;
using CrudEmployee.Domain.Abstract;

namespace CrudEmployee.Domain.Entities
{
    public class Employee : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Patronymic { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public virtual Position Position { get; set; }
        public virtual Department Department { get; set; }
        public virtual string Image { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
    }
}
