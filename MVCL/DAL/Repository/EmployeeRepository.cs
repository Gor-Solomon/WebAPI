using MVCL.DAL.DataAccess;
using MVCL.DAL.Repository.Base;
using MVCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCL.DAL.Repository
{
    public class EmployeeRepository : BaseRepository<Employee, AppDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
