using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proxsure_Auth.Models.SuscriptionModels;

namespace Proxsure_Auth.Models.User {
    public class NewUserModel {
        [Required]
        [Display (Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display (Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display (Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength (100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType (DataType.Password)]
        [Display (Name = "Password")]
        public string Password { get; set; }

        [DataType (DataType.Password)]
        [Display (Name = "Confirm password")]
        [Compare ("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required (ErrorMessage = "Suscription Type Required")]
        [Display (Name = "Suscription Type")]
        public int SuscriptionId { get; set; }

        public string ProfilePictureUrl { get; set; }
        public List<SelectListItem> Suscriptions { get; set; }
    }
}