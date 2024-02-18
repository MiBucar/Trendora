using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;
using Wardrobe.Models.Models;
using Wardrobe.Models.ViewModels;

namespace Wardrobe.Services.Mapper
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Size, SizeDTO>().ReverseMap();
            CreateMap<Color, ColorDTO>().ReverseMap();
            CreateMap<OrderInfo, OrderInfoDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<Collection, CollectionDTO>().ReverseMap();
            CreateMap<Gender, GenderDTO>().ReverseMap();
        }
    }
}
