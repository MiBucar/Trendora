using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Data_Access;
using Wardrobe.Models.DTOs;
using Wardrobe.Models.Models;
using Wardrobe.Services.Interfaces;

namespace Wardrobe.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, ApplicationDbContext db)
        {
            _db = db;
            _mapper = mapper;   
        }        

        public async Task<ProductDTO> Create(ProductDTO pDTO)
        {
            var obj = _mapper.Map<ProductDTO, Product>(pDTO);
            obj.DateCreated = DateTime.Now;

            var colorIds = obj.Colors.Select(c => c.Id).ToList();
            var existingColors = _db.ColorList.Where(c => colorIds.Contains(c.Id)).ToList();
            obj.Colors = existingColors;

            var createdObj = _db.WardrobeList.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDTO>(createdObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.WardrobeList.FirstOrDefaultAsync(x => x.WardrobeModelId == id);
            if (obj != null)
            {
                _db.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.WardrobeList.Include(x => x.ItemType).Include(x => x.Colors));
        }

        public async Task<IEnumerable<ProductDTO>> GetByCategory(string category)
        {
            switch (category)
            {
                case "clothing":
                    return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.WardrobeList.Include(x => x.ItemType).Include(x => x.Colors).Where(x => x.ItemType.IsClothing == true));
                case "shoes":
                    return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.WardrobeList.Include(x => x.ItemType).Include(x => x.Colors).Where(x => x.ItemType.IsShoes == true));
                case "accessory":
                    return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.WardrobeList.Include(x => x.ItemType).Include(x => x.Colors).Where(x => x.ItemType.IsAccessory == true));
                default:
                    return new List<ProductDTO>();  
            }
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var obj = await _db.WardrobeList.Include(x => x.ItemType).Include(x => x.Colors).FirstOrDefaultAsync(x => x.WardrobeModelId == id);
            if (obj != null)
            {
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return new ProductDTO();
        }

        public async Task<IEnumerable<ProductDTO>> SearchByText(string text)
        {
            var searchTerms = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var query = _db.WardrobeList.AsQueryable();

            foreach (var term in searchTerms)
            {
                query = query.Where(x => x.ItemType.Model.Contains(term));
            }

            var results = await query.ToListAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(results);
        }

        public async Task<IEnumerable<ProductDTO>> SortByPrice(string type)
        {
            if (type == "ascending")
            {
                var results = await _db.WardrobeList.OrderBy(x => x.Price).ToListAsync();
                return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(results);
            }
            else if (type == "descending")
            {
                var results = await _db.WardrobeList.OrderByDescending(x => x.Price).ToListAsync();
                return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(results);
            }
            return new List<ProductDTO>();
        }

        public async Task<ProductDTO> Update(ProductDTO pDTO)
        {
            var obj = await _db.WardrobeList.FirstOrDefaultAsync(x => x.WardrobeModelId == pDTO.WardrobeModelId);
            if ( obj != null)
            {
                var selectedColors = pDTO.Colors.Select(x => x.Id).ToList();
                var existingColors = _db.ColorList.Where(x => selectedColors.Contains(x.Id)).ToList();  

                obj.Colors = existingColors;
                obj.Name = pDTO.Name;
                obj.Description = pDTO.Description;
                obj.ItemTypeModelId = pDTO.ItemTypeModelId;
                obj.Price = pDTO.Price;
                obj.ImageData = pDTO.ImageData;
                _db.WardrobeList.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return pDTO;
        }
    }
}
