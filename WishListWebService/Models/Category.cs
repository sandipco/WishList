using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishListWebService.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string Description { get; set; }
        public string PictureId { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<WishList> WishLists { get; set; }
    }
}
