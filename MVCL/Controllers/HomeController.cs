using Microsoft.AspNetCore.Mvc;
using MVCL.Repository;
using MVCL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCL.Controllers
{
    public class HomeController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;
        
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            return View(_employeeRepository.GetAllEmployees());
        }

        public ViewResult Details(int? Id)
        {
            var d = new HomeDetailsViewModel();
            d.PageTitle = "Employee Data";
            d.Employee = _employeeRepository.GetEmployee(Id.Value);
            return View(d);
        }
    }
}
