namespace WebApplication4.Models;

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