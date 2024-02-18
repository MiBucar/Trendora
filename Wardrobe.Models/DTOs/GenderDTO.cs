using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe.Models.DTOs
{
    public class GenderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CollectionDTO> Collections { get; set; }
    }
}
