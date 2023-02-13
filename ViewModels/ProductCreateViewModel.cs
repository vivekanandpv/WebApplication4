namespace WebApplication4.ViewModels;

public class ProductCreateViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal BasePrice { get; set; }
    public decimal TaxRate { get; set; }
}