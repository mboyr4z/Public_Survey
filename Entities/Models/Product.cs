using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Summary  { get; set; } = string.Empty;
    public string? ImageUrl  { get; set; } = string.Empty;
    public int? CategoryId { get; set; } //a
    public bool Showcase { get; set; }

}
