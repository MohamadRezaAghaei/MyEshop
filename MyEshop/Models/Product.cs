﻿using System.Collections.Generic;

namespace MyEshop.Models
{
    public class Product
    {
        //public Product()
        //{
        //        Categories = new List<Category>();  
        //}
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Description { get; set; }
        public int ItemId { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public Item Item { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }
    }
}
