using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCL.DAL.DataAccess;
using MVCL.DAL.Repository.Base;
using MVCL.Models;

namespace MVCL.DAL.Repository
{
    public class MockEmployeeRpository : BaseRepository<Employee, AppDbContext>, IEmployeeRepository
    {
        List<Employee> _employees;

        public MockEmployeeRpository(AppDbContext appDbContext) : base(appDbContext)
        {
            _employees = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Gor", Email = "Dop", Department = DepartmentEnumType.Finances},
                new Employee() {Id = 2, Name = "Vor", Email = "ppa", Department = DepartmentEnumType.IT},
                new Employee() {Id = 3, Name = "Shor", Email = "dwad", Department = DepartmentEnumType.Sales},
            };
        }

        public override async Task<Employee> Add(Employee entity)
        {
            if (_employees.Count > 0)
            {
                entity.Id = _employees.Last().Id + 1;
            }
            else
            {
                entity.Id = 1;
            }

            _employees.Add(entity);

            return entity;
        }
    }
}
