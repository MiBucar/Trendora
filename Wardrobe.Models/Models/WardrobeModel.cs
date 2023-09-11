using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe.Models.Models
{
    public class WardrobeModel
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string ItemType { get; set; }
        public int Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
