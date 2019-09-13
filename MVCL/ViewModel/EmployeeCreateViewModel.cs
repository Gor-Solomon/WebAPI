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
        public IFormFile Photo { get; set; }
    }
}
