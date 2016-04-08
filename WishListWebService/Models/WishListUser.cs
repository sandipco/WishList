using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WishListWebService.Models
{
    public class WishListUser: IdentityUser
    {
        public string UserType { get; set; }
        [Required,StringLength(20,MinimumLength =2)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required,StringLength(30,MinimumLength =2)]
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<WishList> WishLists { get; set; }

    }
}
