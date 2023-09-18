using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe.Models.DTOs
{
    public class ItemTypeModelDTO
    {
        public int ItemTypeId { get; set; }
        [Required(ErrorMessage = "Please enter a model type")]
        public string Model { get; set; }
    }
}
