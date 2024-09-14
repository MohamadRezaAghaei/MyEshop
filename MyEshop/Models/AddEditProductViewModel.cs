﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Runtime;

namespace MyEshop.Models
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int QuantityInStock { get; set; }
        public IFormFile Picture { get; set; }
        public List<Category> categories { get; set; }

        

    }
}
