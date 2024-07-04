using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category
{
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string? Image { get; set; }

    public int? ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }
}