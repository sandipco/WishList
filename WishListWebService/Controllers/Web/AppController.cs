using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListWebService.Models;

namespace WishListWebService.Controllers.Web
{
    public class AppController: Controller
    {
        private WishListContext _ctx;

        public AppController(WishListContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            var wishLists = _ctx.WishLists.OrderBy(t=>t.CreatedDate).ToList();
            return View(wishLists);
        }
    }
}
