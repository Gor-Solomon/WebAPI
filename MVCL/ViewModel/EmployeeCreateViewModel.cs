using Microsoft.AspNetCore.Http;
using MVCL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCL.ViewModel
{
    public class EmployeeCreateViewModel : Employee
    {
        public EmployeeCreateViewModel()
        {

        }

        public EmployeeCreateViewModel(Employee employee)
        {
            base.Id = employee.Id;
            base.Name = employee.Name;
            base.Department = employee.Department;
            base.Email = employee.Email;
            base.PhotoPath = employee.PhotoPath;
        }
        public IFormFile Photo { get; set; }
    }
}
