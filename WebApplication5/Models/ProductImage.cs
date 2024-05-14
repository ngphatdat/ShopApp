using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models;
[Table("product_images")]
public class ProductImage
{   
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("id")]
    public int Id { get; set; } 
    [Column("image_url")]
    [MaxLength(255)]
    public string ImageUrl { get; set; } = null!;
    [Column("product_id")]
    public int ProductId { get; set; }
}