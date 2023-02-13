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

    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Gstin { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int Pin { get; set; }
        public List<ProductManufacturer> ProductManufacturers { get; set; }
    }

    public class ProductManufacturer
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
