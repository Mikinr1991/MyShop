﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Core.Models
{
    public class Product : BaseEntity
    {
        //public Product()
        //{
        //    this.Id = System.Guid.NewGuid().ToString();
        //}

       // public string Id { get; set; }

        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }


        
    }
}
