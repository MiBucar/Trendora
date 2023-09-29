using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;
using Wardrobe.Models.Models;

namespace Wardrobe.Services.Mapper
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ItemType, ItemTypeDTO>().ReverseMap();
            CreateMap<Size, SizeDTO>().ReverseMap();
            CreateMap<Color, ColorDTO>().ReverseMap();
        }
    }
}
