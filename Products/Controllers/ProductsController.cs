using System.Text;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Prducts.IRepository;
using Products.Dtos;
using Products.Models;

namespace Prducts.Controllers;

[Route("/api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductsRepo _repo;
    private readonly IMapper _mapper;

    public ProductsController(IProductsRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
    {
        Console.WriteLine(" --> Getting products");

        var products = _repo.GetAllProducts();

        return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public ActionResult<ProductReadDto> GetProductById(int id)
    {

        var product = _repo.GetProductById(id);

        if (product != null)
        {
            return Ok(_mapper.Map<ProductReadDto>(product));
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<ProductReadDto> CreateProductAsync(ProductCreateDto productCreateDto)
    {

        Console.WriteLine(" --> Creating a new product... ");
        Console.WriteLine($"Name: {productCreateDto.Name}, Size: {productCreateDto.Size}, Description: {productCreateDto.Description}");

        // Create th auto mapping
        var productModel = _mapper.Map<Product>(productCreateDto);
        Console.WriteLine($"Mapped Name: {productModel.Name}, Mapped Size: {productModel.Size}, Mapped Description: {productModel.Description}");
        _repo.CreateProdudct(productModel);
        _repo.saveChanges();

        var productReadDto = _mapper.Map<ProductReadDto>(productModel);

        return CreatedAtRoute(nameof(GetProductById), new { Id = productReadDto.Id }, productReadDto);
    }
}