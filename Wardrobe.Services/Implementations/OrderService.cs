using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Common;
using Wardrobe.Data_Access;
using Wardrobe.Models.DTOs;
using Wardrobe.Models.Models;
using Wardrobe.Models.ViewModels;
using Wardrobe.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wardrobe.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDatabaseContext _db;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }        

        public async Task<OrderDTO> Create(OrderDTO order)
        {
            try
            {
                var obj = _mapper.Map<OrderDTO, Order>(order);

                obj.OrderInfo.Guid = Guid.NewGuid();

                _db.OrderInfoList.Add(obj.OrderInfo);
                await _db.SaveChangesAsync();

                foreach (var details in obj.OrderDetails)
                {
                    details.OrderInfoId = obj.OrderInfo.Id;

                    var newDetails = new OrderDetail
                    {
                        OrderInfoId = details.OrderInfoId,
                        ProductId = details.ProductId,
                        Count = details.Count,
                        Price = details.Price,
                        Size = details.Size,
                        ProductName = details.ProductName,
                        ImageData = details.ImageData,
                    };

                    _db.OrderDetailList.Add(newDetails);
                    await _db.SaveChangesAsync();
                }

                return new OrderDTO()
                {
                    OrderInfo = _mapper.Map<OrderInfo, OrderInfoDTO>(obj.OrderInfo),
                    OrderDetails = _mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailDTO>>(obj.OrderDetails).ToList(),
                };
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return order;
        }

        public async Task<int> Delete(int id)
        {
            var orderInfo = await _db.OrderInfoList.FirstOrDefaultAsync(x => x.Id == id);
            if (orderInfo != null)
            {
                IEnumerable<OrderDetail> orderDetails = _db.OrderDetailList.Where(x => x.OrderInfoId == orderInfo.Id);
                _db.OrderDetailList.RemoveRange(orderDetails);
                _db.OrderInfoList.Remove(orderInfo);
                return _db.SaveChanges();
            }
            return 0;
        }

        public async Task<OrderDTO> Get(int id)
        {
            Order order = new Order()
            {
                OrderInfo = _db.OrderInfoList.FirstOrDefault(x => x.Id == id),
                OrderDetails = _db.OrderDetailList.Where(x => x.OrderInfoId == id)
            };

            if (order != null)
            {
                return _mapper.Map<Order, OrderDTO>(order);
            }

            return new OrderDTO();
        }

        public async Task<IEnumerable<OrderDTO>> GetAll(string? userId = null, string? status = null)
        {
            List<Order> OrderFromDb = new List<Order>();
            IEnumerable<OrderInfo> orderInfoList = _db.OrderInfoList;
            IEnumerable<OrderDetail> orderDetailList = _db.OrderDetailList;

            foreach (OrderInfo orderInfo in orderInfoList.Where(x => x.UserId == userId))
            {
                Order order = new()
                {
                    OrderInfo = orderInfo,
                    OrderDetails = orderDetailList.Where(u => u.OrderInfoId == orderInfo.Id),
                };
                OrderFromDb.Add(order);
            }

            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(OrderFromDb);
        }

        public async Task<OrderInfoDTO> MarkPaymentSuccessful(int id)
        {
            var data = await _db.OrderInfoList.FindAsync(id);
            if (data == null)
            {
                return new OrderInfoDTO();
            }
            if (data.Status == SD.Status_Pending)
            {
                data.Status = SD.Status_Confirmed;
                await _db.SaveChangesAsync();
                return _mapper.Map<OrderInfo, OrderInfoDTO>(data);
            }
            return new OrderInfoDTO();
        }

        public async Task<OrderInfoDTO> UpdateInfo(OrderInfoDTO orderInfo)
        {
            if (orderInfo != null)
            {
                var orderHeaderFromDb = _db.OrderInfoList.FirstOrDefault(u => u.Id == orderInfo.Id);
                orderHeaderFromDb.FirstName = orderInfo.FirstName;
                orderHeaderFromDb.LastName = orderInfo.LastName;
                orderHeaderFromDb.PhoneNumber = orderInfo.PhoneNumber;
                orderHeaderFromDb.Address = orderInfo.Address;
                orderHeaderFromDb.Town = orderInfo.Town;
                orderHeaderFromDb.ZipCode = orderInfo.ZipCode;
                orderHeaderFromDb.Country = orderInfo.Country;
                orderHeaderFromDb.Status = orderInfo.Status;

                await _db.SaveChangesAsync();
                return _mapper.Map<OrderInfo, OrderInfoDTO>(orderHeaderFromDb);
            }
            return new OrderInfoDTO();
        }

        public async Task<bool> UpdateOrderStatus(int orderId, string status)
        {
            var data = await _db.OrderInfoList.FindAsync(orderId);
            if (data == null)
            {
                return false;
            }
            data.Status = status;
            if (status == SD.Status_Shipped)
            {
                data.OrderDate = DateTime.Now;
            }
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
