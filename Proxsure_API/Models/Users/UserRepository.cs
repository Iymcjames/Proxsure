using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proxsure_API.Models.Context;

namespace Proxsure_API.Models.Users
{
    public class UserRepository //: IUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationUser> roleManager;

        public UserRepository(ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
         RoleManager<ApplicationUser> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        // public Task<IActionResult> Register(ApplicationUser User)
        // {
        //     if(User == null)
        //     return BadRequest();
        // }
    }
}