using System.ComponentModel.DataAnnotations;

namespace Products.Models;

public class Product
{

    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string Size { get; set; }
    public string Description { get; set; }

}