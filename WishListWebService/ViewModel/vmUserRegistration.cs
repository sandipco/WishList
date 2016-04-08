using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WishListWebService.ViewModel
{
    public class vmUserRegistration
    {
        [Required, StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required, StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        [Required,DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; }

      

    }
}
