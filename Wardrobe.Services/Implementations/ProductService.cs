using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ProductDTO> Create(ProductDTO wDto)
        {
            var obj = _mapper.Map<ProductDTO, Product>(wDto);
            obj.DateCreated = DateTime.Now;

            var createdObj = _db.WardrobeList.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDTO>(createdObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.WardrobeList.Include(x => x.ItemType).FirstOrDefaultAsync(x => x.WardrobeModelId == id);
            if (obj != null)
            {
                _db.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.WardrobeList.Include(x => x.ItemType));
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var obj = await _db.WardrobeList.FirstOrDefaultAsync(x => x.WardrobeModelId == id);
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
                query = query.Where(x => x.Color.Contains(term) || x.ItemType.Model.Contains(term));
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

        public async Task<ProductDTO> Update(ProductDTO wDto)
        {
            var obj = await _db.WardrobeList.FirstOrDefaultAsync(x => x.WardrobeModelId == wDto.WardrobeModelId);
            if ( obj != null)
            {
                obj.ItemTypeModelId = wDto.ItemTypeModelId;
                obj.Price = wDto.Price;
                obj.Color = wDto.Color;
                obj.ImageData = wDto.ImageData;
                _db.WardrobeList.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return wDto;
        }
    }
}
