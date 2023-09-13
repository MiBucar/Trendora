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
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the color")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Please select the item type")]
        public string ItemType { get; set; }
        [Required]
        public int Price { get; set; }
        public byte[] ImageData { get; set; }
    }
}
