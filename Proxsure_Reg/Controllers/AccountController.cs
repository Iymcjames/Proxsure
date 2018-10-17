using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proxsure_Reg.Models;
using Proxsure_Reg.Models.ViewModels;

namespace Proxsure_Reg.Controllers {

    public class AccountController : Controller {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        public AccountController (UserManager<ApplicationUser> userManager, ApplicationDbContext applicationDbContext, IMapper mapper) {
            this.mapper = mapper;
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;

        }

        [HttpGet]
        public ActionResult Register () {
            return Ok ("I got here");
        }

        [HttpPost]
        public async Task<IActionResult> Register ([FromBody] RegistrationViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            var userIdentity = mapper.Map<ApplicationUser> (model);

            var result = await userManager.CreateAsync (userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult (Errors.AddErrorsToModelState (result, ModelState));

            await applicationDbContext.Mentees.AddAsync (new Mentee { ApplicationUserId = Convert.ToInt16 (userIdentity.Id), });
            await applicationDbContext.SaveChangesAsync ();

            return new OkObjectResult ("User created");
        }
    }
}