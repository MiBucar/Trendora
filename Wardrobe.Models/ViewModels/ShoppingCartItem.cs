using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Models.ViewModels
{
    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public int ProductPrice { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
        public string Size { get; set; }
        public OrderDTO Order { get; set; }
    }
}
