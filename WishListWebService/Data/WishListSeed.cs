using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishListWebService.Models;

namespace WishListWebService.Data
{
    public class WishListSeed
    {
        private WishListContext _context;
        private UserManager<WishListUser> _userManager;

        public WishListSeed(WishListContext context,UserManager<WishListUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task EnsureSeedDone()
        {
            if( await _userManager.FindByEmailAsync("sandipco@gmail.com")==null)
            {
                var newUser = new WishListUser()
                {
                     UserType="AD",
                     FirstName="Sandip",
                     LastName="Timsina",
                     UserName="sandipco",
                     Email="sandipco@gmail.com"
                };
               await  _userManager.CreateAsync(newUser, "P@ssw0rd!");
            }
            if(_context.WishLists.Any())
            {
                var wishList = new WishList()
                {
                  
                };
            }
        }
    }
}
