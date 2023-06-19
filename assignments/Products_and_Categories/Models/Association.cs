#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Products_and_Categories.Models;

public class Association
{
    [Key]
    public int AssociationId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int ProductId { get; set; }

    public int CategoryId { get; set; }


    public Product? Product { get; set; }
    public Category? Category { get; set; }
}