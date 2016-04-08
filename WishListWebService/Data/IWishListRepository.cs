using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishListWebService.Models;
using WishListWebService.ViewModel;

namespace WishListWebService.Data
{
    public interface IWishListRepository
    {
        IEnumerable<WishList> GetWishList(int id);
        void AddWishList(WishList WishList);

        Boolean SaveAll();
    }
}
