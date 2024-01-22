using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Models.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Required]
        public int OrderInfoId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Count { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string ProductName { get; set; }
        public byte[] ImageData { get; set; }
    }
}
