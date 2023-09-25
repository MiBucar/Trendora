using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.Models;

namespace Wardrobe.Models.DTOs
{
    public class SizeModelDTO
    {
        public int Id { get; set; }
        public string ItemSize { get; set; }
        public bool IsAvailable { get; set; }
        public int ItemTypeModelId { get; set; }
        public ItemTypeModel ItemTypeModel { get; set; }

    }
}
