using System.ComponentModel.DataAnnotations;

namespace Wardrobe.Models.Models
{
    public class Category
    {
        [Key]
        public int ItemTypeId { get; set; }
        public string Model { get; set; }
        [Required(ErrorMessage = "Please choose an image")]
        public byte[] Image { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Size> Sizes { get; set; }
    }
}