using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Proxsure_Auth.Models.User;

namespace Proxsure_Auth.Areas.Identity.Pages.Account {
    [AllowAnonymous]
    public class RegisterModel : PageModel {
        public ApplicationDbContext _context { get; }
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel (
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender) {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            newUser = new NewUserModel ();
        }

        [BindProperty]
        public NewUserModel newUser { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet (string returnUrl = null) {
            newUser.Suscriptions = new List<SelectListItem> ();
            newUser.Suscriptions = _context.Suscriptions
                .Select (a => new SelectListItem () {
                    Value = a.Id.ToString (),
                        Text = a.Name
                })
                .ToList ();
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync (string returnUrl = null) {
            returnUrl = returnUrl ?? Url.Content ("~/");
            if (ModelState.IsValid) {
                var user = new ApplicationUser {
                    UserName = newUser.Email,
                    Email = newUser.Email,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    SuscriptionId = newUser.SuscriptionId,
                    SuscriptionStartDate = DateTime.Now,
                };

                if (user.SuscriptionId > 0) {
                   user.Suscription =await  _context.Suscriptions.FindAsync (user.SuscriptionId);
                }
                var result = await _userManager.CreateAsync (user, newUser.Password);
                if (result.Succeeded) {
                    _logger.LogInformation ("User created successfully!.");
                    var roleResult = await _userManager.AddToRoleAsync (user, "Mentee");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync (user);
                    var callbackUrl = Url.Page (
                        "/Account/ConfirmEmail",
                        pageHandler : null,
                        values : new { userId = user.Id, code = code },
                        protocol : Request.Scheme);

                    await _emailSender.SendEmailAsync (newUser.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync (user, isPersistent : false);
                    return LocalRedirect (returnUrl);
                }
                foreach (var error in result.Errors) {
                    ModelState.AddModelError (string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page ();
        }
    }
}