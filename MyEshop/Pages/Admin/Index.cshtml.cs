using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEshop.Data;
using MyEshop.Models;
using System.Collections;
using System.Collections.Generic;

namespace MyEshop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private MyEshopContext _context;
        public IndexModel(MyEshopContext context)
        {
            _context = context;  
        }
        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _context.Products.Include(p=>p.Item);
        }
        public void OnPost() 
        { 

        }
    }
}
