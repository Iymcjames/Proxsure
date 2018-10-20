using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proxsure_API.Models.Context;
using Proxsure_API.Models.SuscriptionModels;
//using Proxsure_API.Models;

namespace Proxsure_API.Controllers {
    [Route ("api/[controller]")]
    public class SuscriptionController : Controller {
        private readonly ISuscriptionRepository suscriptionRepository;
        private readonly ApplicationDbContext applicationDbContext;
        public SuscriptionController (ISuscriptionRepository suscriptionRepository) {
            this.suscriptionRepository = suscriptionRepository;
        }

        // GET api/suscription
        [HttpGet ("")]
        public async Task<IActionResult> GetSuscriptions () {
            return Ok (await suscriptionRepository.GetAllSuscriptions ());
        }

        // GET api/suscription/5
        [HttpGet ("{id}")]
        public ActionResult<string> GetSuscriptionById (int id) {
            return "value" + id;
        }

        // POST api/suscription
        [HttpPost ("")]
        public void Post ([FromBody] string value) { }

        // PUT api/suscription/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/suscription/5
        [HttpDelete ("{id}")]
        public void DeleteById (int id) { }
    }
}