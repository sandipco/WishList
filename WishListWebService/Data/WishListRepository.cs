using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishListWebService.Models;
using WishListWebService.ViewModel;

namespace WishListWebService.Data
{
    public class WishListRepository:IWishListRepository
    {
        private WishListContext _context;

        public WishListRepository(WishListContext context)
        {
            _context = context;
        }

        public void AddWishList(WishList wishList)
        {
            _context.Add(wishList);
        }

        public IEnumerable<WishList> GetWishList(int id)
        {
            return _context.
                WishLists.
                OrderBy(t => t.CreatedDate).
                ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
