using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderDTO> Get(int id);
        public Task<OrderDTO> Create(OrderDTO order);
        public Task<int> Delete(int id);
        public Task<bool> UpdateOrderStatus(int orderId, string status);
        public Task<IEnumerable<OrderDTO>> GetAll(string? userId = null, string? status = null);
        public Task<OrderInfoDTO> UpdateInfo(OrderInfoDTO orderInfo);
        public Task<OrderInfoDTO> MarkPaymentSuccessful(int id);
    }
}
