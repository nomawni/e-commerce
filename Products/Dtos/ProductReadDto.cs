namespace Products.Dtos;

public class ProductReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Size { get; set; }
    public string Description { get; set; }
}