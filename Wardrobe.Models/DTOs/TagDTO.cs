using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.Models;

namespace Wardrobe.Models.DTOs
{
    public class TagDTO
    {
        public int TagId { get; set; }
        [Required]
        public string Title { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
