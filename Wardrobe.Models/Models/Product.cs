using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Models.Models
{
    public class Product
    {
        [Key]
        public int WardrobeModelId { get; set; }
        public string Name { get; set; }
        public int ItemTypeModelId { get; set; }
        [ForeignKey("ItemTypeModelId")]
        public ItemType ItemType { get; set; }
        public int Price { get; set; }
        public byte[] ImageData { get; set; }   
        public DateTime DateCreated { get; set; }
        public List<Color> Colors { get; set; }
    }
}
