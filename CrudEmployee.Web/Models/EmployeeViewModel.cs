using System;

namespace CrudEmployee.Web.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int PositionId { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}