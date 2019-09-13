using Microsoft.AspNetCore.Mvc;
using MVCL.DAL;
using MVCL.Models;
using MVCL.DAL.Repository;
using MVCL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCL.DAL.DataAccess;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MVCL.Controllers
{
    public class HomeController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;
        readonly IHostingEnvironment _hostingEnvironment;
        readonly AppDbContext _appDbContext;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<ViewResult> Index()
        {
            var result = await _employeeRepository.GetAll();
            return View(result);
        }

        public async Task<ViewResult> Details(int? Id)
        {
            var d = new HomeDetailsViewModel();
            d.PageTitle = "Employee Data";
            d.Employee = await _employeeRepository.GetById(Id.Value);
            return View(d);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;

                if (model.Photo != null)
                {
                    var uplodedFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uplodedFolder, fileName);
                    await model.Photo.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }

                model.PhotoPath = fileName;
                var result = await _employeeRepository.Add((Employee)model);
                return RedirectToAction("Details", new { Id = result.Id });
            }

            return View();
        }
    }
}
