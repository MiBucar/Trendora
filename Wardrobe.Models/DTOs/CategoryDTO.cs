using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.Models;

namespace Wardrobe.Models.DTOs
{
    public class CategoryDTO
    {
        public int ItemTypeId { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please choose an image")]
        public byte[] Image { get; set; }
        public List<SizeDTO> Sizes { get; set; }
    }
}
