using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCL.Models;

namespace MVCL.Repository
{
    public class EmployeeRpository : IEmployeeRepository
    {
        List<Employee> _employees;

        public EmployeeRpository()
        {
            _employees = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Gor", Email = "Dop", Department = DepartmentEnumType.Finances},
                new Employee() {Id = 2, Name = "Vor", Email = "ppa", Department = DepartmentEnumType.IT},
                new Employee() {Id = 3, Name = "Shor", Email = "dwad", Department = DepartmentEnumType.Sales},
            };
        }

        public Employee Add(Employee employee)
        {
            if (_employees.Count > 0)
            {
                employee.Id = _employees.Last().Id + 1;
            }
            else
            {
                employee.Id = 1;
            }
            
            _employees.Add(employee);

            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees.ToList();
        }

        public Employee GetEmployee(int Id)
        {
            return _employees.FirstOrDefault(x => x.Id == Id);
        }
    }
}
