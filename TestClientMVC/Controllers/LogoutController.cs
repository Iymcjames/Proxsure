using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
//using TestClientMVC.Models;

namespace TestClientMVC.Controllers {
    public class LogoutController : Controller {
        public LogoutController () { }

        // GET api/logout
        public async Task Logout () {
            await HttpContext.SignOutAsync ("Cookies");
            await HttpContext.SignOutAsync ("oidc");
        }

        // GET api/logout/5
        [HttpGet ("{id}")]
        public ActionResult<string> GetById (int id) {
            return "value" + id;
        }

        // POST api/logout
        [HttpPost ("")]
        public void Post ([FromBody] string value) { }

        // PUT api/logout/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/logout/5
        [HttpDelete ("{id}")]
        public void DeleteById (int id) { }
    }
}