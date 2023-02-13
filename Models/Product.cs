namespace WebApplication4.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double BasePrice { get; set; }
        public double TaxRate { get; set; }
        public List<ProductManufacturer> ProductManufacturers { get; set; }
    }
}
