using System.ComponentModel.DataAnnotations;
using Wardrobe.Models.Models;

namespace Wardrobe.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public Guid IdGuid { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Please provide an image")]
        public byte[] ImageData { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }

        public CategoryDTO Category { get; set; }

        public List<TagDTO> Tags { get; set; }
        public List<ColorDTO> Colors { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a gender")]
        public int GenderId { get; set; }

        public GenderDTO Gender { get; set; }
    }
}
