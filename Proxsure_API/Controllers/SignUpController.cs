using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proxsure_API.Models.Users;
//using Proxsure_API.Models;

namespace Proxsure_API.Controllers
{
    [Route("api/[controller]")]
    public class SignUpController : Controller
    {
        public SignUpController() { }

        // GET api/signup
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> Gets()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/signup/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            return "value" + id;
        }

        // POST api/signup
        [HttpPost("")]
        public IActionResult Post([FromBody] ApplicationUser user) {
            return  Ok(user);
         }

        // PUT api/signup/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/signup/5
        [HttpDelete("{id}")]
        public void DeleteById(int id) { }
    }
}