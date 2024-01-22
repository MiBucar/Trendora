using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.ViewModels;

namespace Wardrobe.Models.DTOs
{
    public class OrderDTO
    {
        public OrderInfoDTO OrderInfo { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
