using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe.Models.DTOs
{
    public class CollectionDTO
    {
        public int CollectionId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<GenderDTO> Genders { get; set; }
        public List<TagDTO> Tags { get; set; }
    }
}
