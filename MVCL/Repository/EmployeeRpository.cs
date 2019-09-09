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
                new Employee() {Id = 1, Name = "Gor", Email = "Dop"},
                new Employee() {Id = 2, Name = "Vor", Email = "ppa"},
                new Employee() {Id = 3, Name = "Shor", Email = "dwad"},
            };
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
