using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MyEshop.Data;
using MyEshop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MyEshop.Pages.Admin
{
    public class AddModel : PageModel
    {
        MyEshopContext _context;
        public AddModel(MyEshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel product { get; set; }
        [BindProperty]
        public List<int> selectedGroups { get; set; }
        public void OnGet()
        {
            product = new AddEditProductViewModel()
            {
                categories = _context.Categories.ToList()
            };
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var Item = new Item()
            {
                Price = product.Price,
                QuantityInStock = product.QuantityInStock
            };
            _context.Items.Add(Item);
            _context.SaveChanges();

            var pro = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Item = Item
               
            };
            _context.Add(pro);
            _context.SaveChanges();
            pro.ItemId = pro.Id;
            _context.SaveChanges();

            if (product.Picture?.Length > 0)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    pro.Id + Path.GetExtension(product.Picture.FileName));
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    product.Picture.CopyTo(stream);
                }
            }
            if (selectedGroups.Any() && selectedGroups.Count> 0)
            {
                foreach (int gr in selectedGroups)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        CategoryId = gr,
                        ProductId = pro.Id
                    }) ;
                    _context.SaveChanges(); 
                }
            }

            return RedirectToPage("Index");
        }
    }
}
