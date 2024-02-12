using System.ComponentModel.DataAnnotations;

namespace Wardrobe.Models.Models
{
    public class ItemType
    {
        [Key]
        public int ItemTypeId { get; set; }
        public string Model { get; set; }
        public bool IsClothing { get; set; }
        public bool IsShoes { get; set; }
        public bool IsAccessory { get; set; }
        [Required(ErrorMessage = "Please choose an image")]
        public byte[] Image { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Size> Sizes { get; set; }
    }
}