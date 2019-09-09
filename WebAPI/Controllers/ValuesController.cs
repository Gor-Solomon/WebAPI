using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet, EnableQuery()]
        public ActionResult<IEnumerable<Employe>> Get()
        {
            var result = new List<Employe>() {
                    new Employe(){Id = 1, Name = "Ahmad", Department = "IT" },
                    new Employe(){Id = 1, Name = "Goruen", Department = "Back End" },
                    new Employe(){Id = 1, Name = "Lori", Department = "Accounting" },};

            return new ActionResult<IEnumerable<Employe>>(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
