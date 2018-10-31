using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proxsure_API.Models.SuscriptionModels;
using Proxsure_API.Models.Users;
using Proxsure_API.Models.Users.ViewModels;
//using Proxsure_API.Models;

namespace Proxsure_API.Controllers {

    public class AuthorizeToken : AuthorizeAttribute

    {
    //    public AuthorizeToken()
    //    {
    //        AuthenticationSchemes = AuthenticationSchemes.JwtBearerDefaults.AuthenticationScheme
    //    } 
    }
    [Route ("api/[controller]")]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : Controller {
        private readonly ISuscriptionRepository suscriptionRepository;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationUser> roleManager;

        public UserController (
            ISuscriptionRepository suscriptionRepository,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) {
            this.suscriptionRepository = suscriptionRepository;
            this.mapper = mapper;
            this.userManager = userManager;

        }

        // GET api/user
        [HttpGet ("")]
        public ActionResult<IEnumerable<string>> Gets () {
            return new string[] { "value1", "value2" };
        }

        // GET api/user/5
        [HttpGet ("{id}")]
        public ActionResult<string> GetById (int id) {
            return "value" + id;
        }

        // POST api/user
        [HttpPost ("")]
        public async Task<IActionResult> Post ([FromBody] UserViewModel userVM) {

            // using (var reader = new StreamReader (Request.Body)) {
            //     var body = reader.ReadToEnd ();

            //     // Do something
            // }
            if (userVM == null)
                return BadRequest ();

            if (userVM.User.SuscriptionId > 0) {
                userVM.User.Suscription = mapper.Map<Suscription> (await suscriptionRepository.GetSuscription (userVM.User.SuscriptionId));
            }
            var result = await userManager.CreateAsync (userVM.User, userVM.Password);
            if (result.Succeeded) {
                var code = await userManager.GenerateEmailConfirmationTokenAsync (userVM.User);
            }

            return Ok (result);

        }

        // PUT api/user/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/user/5
        [HttpDelete ("{id}")]
        public void DeleteById (int id) { }
    }
}