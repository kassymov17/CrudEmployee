using CrudEmployee.Domain.Abstract;
using CrudEmployee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEmployee.Domain.Services
{
    public interface IEmployeeService
    {
        IList<Employee> GetAll();
        Employee GetOne(int id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IList<Employee> GetAll()
        {
            return _employeeRepository
                .GetAll()
                .ToList();
        }

        public Employee GetOne(int id)
        {
            return _employeeRepository.GetOne(id);
        }

        public void Create(Employee employee)
        {
            _employeeRepository.Create(employee);
        }

        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }
    }
}
