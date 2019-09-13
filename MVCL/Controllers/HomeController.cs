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
using Microsoft.AspNetCore.Http.Internal;

namespace MVCL.Controllers
{
    public class HomeController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;
        readonly IHostingEnvironment _hostingEnvironment;

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
            if (d.Employee is null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", Id);
            }
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
                string fileName = await ProcessUploadedFile(model);

                model.PhotoPath = fileName;
                var result = await _employeeRepository.Add((Employee)model);
                return RedirectToAction("Details", new { Id = result.Id });
            }

            return View();
        }

        private async Task<string> ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string fileName = null;
            if (model.Photo != null)
            {
                var uplodedFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uplodedFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(fileStream);
                }
            }

            return fileName;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var result = await _employeeRepository.GetById(Id);

            EmployeeCreateViewModel employee = new EmployeeCreateViewModel(result);

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeCreateViewModel Model)
        {
            if (ModelState.IsValid)
            {
                var emp = await _employeeRepository.GetById(Model.Id);
                emp.Name = Model.Name;
                emp.Department = Model.Department;
                emp.Email = Model.Email;
                emp.PhotoPath = Model.PhotoPath;

                if (Model.PhotoPath != null)
                {
                    System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "Images", emp.PhotoPath));
                }

                if (Model.Photo != null)
                {
                    emp.PhotoPath = await ProcessUploadedFile(Model);
                }

                Employee updatedEmployee = await _employeeRepository.Edit(emp);

                return RedirectToAction("Details", "Home", new { Id = Model.Id});
            }

            return View();
        }
    }
}
