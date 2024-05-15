using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication5.Models
{       [Table("products")]
       public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
        
        [Column("thumbnail")]
        [MaxLength(255)]
        public string? Thumbnail { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [Column("category_id")]
        [ForeignKey("CategoryId")]
        [JsonPropertyName("category_id")]
        public int? CategoryId { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
