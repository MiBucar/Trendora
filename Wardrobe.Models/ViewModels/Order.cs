using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;
using Wardrobe.Models.Models;

namespace Wardrobe.Models.ViewModels
{
    public class Order
    {
        public OrderInfo OrderInfo { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
