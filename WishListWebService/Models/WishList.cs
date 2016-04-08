﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WishListWebService.Models
{
    public class WishList
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128, MinimumLength =5)]
        public string Title { get; set; }

        [StringLength(128,MinimumLength =0)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public Category WishListCategory { get; set; }
        public WishListUser WishListUser { get; set; }

    }
}
