using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a value for Name field")]
        [Display(Name = "Office Email")]
        public string Name{ get; set; }

        [Required(ErrorMessage = "Please provide a value for Email field")]
        public string Email { get; set; }
        public DepartmentEnumType Department { get; set; }
    }
}
