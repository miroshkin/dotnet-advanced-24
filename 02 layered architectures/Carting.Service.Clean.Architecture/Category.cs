using System.ComponentModel.DataAnnotations;

public class Category
{
    public int CategoryId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public string Image { get; set; }
    
    public Category? ParentCategory { get; set; }
}