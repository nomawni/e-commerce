using System.ComponentModel.DataAnnotations;

namespace Products.Dtos;

public class ProductCreateDto
{

    [Required]
    public string Name { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string Size { get; set; }
    [Required]
    public string Description { get; set; }
}