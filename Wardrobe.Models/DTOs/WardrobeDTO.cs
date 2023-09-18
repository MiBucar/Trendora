using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.Models;

namespace Wardrobe.Models.DTOs
{
    public class WardrobeDTO
    {
        public int WardrobeModelId { get; set; }
        [Required(ErrorMessage = "Please enter the color")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Please enter the price")]
        public int Price { get; set; }
        public byte[] ImageData { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a type")]
        public int ItemTypeModelId { get; set; }
        public ItemTypeModelDTO ItemType { get; set; }

    }
}
