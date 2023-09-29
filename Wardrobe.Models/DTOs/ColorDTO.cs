using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.Models;

namespace Wardrobe.Models.DTOs
{
    public class ColorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorCode { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
