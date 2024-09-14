namespace MyEshop.Models
{
    public class Item
    {
        public int Id { get; set; }
        
        public int Price { get; set; }
        public int QuantityInStock { get; set; }
        

        public Product Product { get; set; }
    }
}
