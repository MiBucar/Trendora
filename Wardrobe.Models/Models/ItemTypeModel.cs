using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Models.Models
{
    public class ItemTypeModel
    {
        [Key]
        public int ItemTypeId { get; set; }
        public string Model { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
