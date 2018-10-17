using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Proxsure_Reg.Models.ViewModels {
    [ModelMetadataType (typeof (RegistrationViewModelAttribute))]

    public partial class RegistrationViewModel {

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public partial class RegistrationViewModelAttribute {
        [Required (ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required (ErrorMessage = "Email is required.")]
        [DataType (DataType.EmailAddress, ErrorMessage = "Email must conform to an email standard")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Password is required")]
        [DataType (DataType.Password)]
        public string Password { get; set; }

        [Required (ErrorMessage = "First Name is required")]
        [Display (Name = "First Name")]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "Last Name is required")]
        [Display (Name = "Last Name")]
        public string LastName { get; set; }
    }
}