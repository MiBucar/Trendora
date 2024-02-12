using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe.Models.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        [Required]
        public string Title { get; set; }
        public List<Product> Products { get; set; }
    }
}
