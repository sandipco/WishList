using AutoMapper;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WishListWebService.Data;
using WishListWebService.Models;
using WishListWebService.ViewModel;

namespace WishListWebService.Controllers.Api
{
    //[Route("api/{id}/wishlists")]
    [Route("api/wishlists")]
    public class WishListApi:Controller
    {
        private IWishListRepository _wishListRepository;

        public WishListApi(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }
        [HttpGet("")]
        public JsonResult Get()
        {
            return Json ( new {name="Sandip"});
        }
        //[HttpGet("")]
        //public JsonResult Get(int id)
        //{
        //    var wishLists = Mapper.Map<IEnumerable<VmWishList>>(_wishListRepository.GetWishList(id));
        //    return Json(wishLists);
        //}

        public JsonResult Post([FromBody] VmWishList vmWishList)
        {
            if (ModelState.IsValid)
            {
                var newWishList = Mapper.Map<WishList>(vmWishList);
                _wishListRepository.AddWishList(newWishList);
                Response.StatusCode =(int) HttpStatusCode.Created;
                return Json(Mapper.Map<VmWishList>(newWishList));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(false);
            }

        }
    }
}
