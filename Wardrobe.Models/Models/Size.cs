using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe.Models.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        public string ItemSize { get; set; }
        public bool IsAvailable { get; set; }
        public int ItemTypeModelId { get; set; }
        public Category ItemTypeModel { get; set; }
    }
}
