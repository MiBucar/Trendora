using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wardrobe.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public List<Tag> Tags { get; set; }
        public int Price { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        public byte[] ImageData { get; set; }   
        public DateTime DateCreated { get; set; }
        public List<Color> Colors { get; set; }
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }
    }
}
