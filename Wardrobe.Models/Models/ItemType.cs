using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

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
        public byte[] Image { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Size> Sizes { get; set; }
    }
}

// ADJUST ITEM TYPE PAGE
// MAKE IMAGES MANDATORY
// ELEMENTS SCALE ACCORDING TO SCREEN RESOLUTION