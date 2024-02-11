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
        private readonly ApplicationDatabaseContext _db;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, ApplicationDatabaseContext db)
        {
            _db = db;
            _mapper = mapper;   
        }        

        public async Task<ProductDTO> Create(ProductDTO pDTO)
        {
            var obj = _mapper.Map<ProductDTO, Product>(pDTO);
            obj.DateCreated = DateTime.Now;
            obj.IdGuid = Guid.NewGuid();

            var colorIds = obj.Colors.Select(c => c.Id).ToList();
            var existingColors = _db.ColorList.Where(c => colorIds.Contains(c.Id)).ToList();
            obj.Colors = existingColors;

            var createdObj = _db.ProductList.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDTO>(createdObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.ProductList.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.ProductList.Include(x => x.ItemType).Include(x => x.Colors));
        }

        public async Task<(IEnumerable<ProductDTO>, int)> GetByCategory(string category, int pageNumber, int pageSize)
        {
            IQueryable<Product> query;

            switch (category)
            {
                case "clothing":
                    query = _db.ProductList.Include(x => x.ItemType).Include(x => x.Colors).Where(x => x.ItemType.IsClothing == true);
                    break;
                case "shoes":
                    query = _db.ProductList.Include(x => x.ItemType).Include(x => x.Colors).Where(x => x.ItemType.IsShoes == true);
                    break;
                case "accessories":
                    query = _db.ProductList.Include(x => x.ItemType).Include(x => x.Colors).Where(x => x.ItemType.IsAccessory == true);
                    break;
                default:
                    return (new List<ProductDTO>(), 0);
            }

            int totalCount = await query.CountAsync();
            var products = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (_mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products), totalCount);
        }


        public async Task<(IEnumerable<ProductDTO>, int)> GetByItemType(string itemType, int pageNumber, int pageSize)
        {
            var query = _db.ProductList.Include(x => x.ItemType).Include(x => x.Colors).Where(x => x.ItemType.Model == itemType);

            int totalCount = await query.CountAsync();
            var products = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (_mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products), totalCount);
        }


        public async Task<ProductDTO> GetById(int id)
        {
            var obj = await _db.ProductList.Include(x => x.ItemType).Include(x => x.Colors).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return new ProductDTO();
        }

        public async Task<ProductDTO> GetByName(string name)
        {
            var obj = await _db.ProductList.Include(x => x.ItemType).Include(x => x.Colors).FirstOrDefaultAsync(x => x.Name == name);
            if (obj != null)
            {
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return new ProductDTO();
        }

        public async Task<IEnumerable<ProductDTO>> SearchByText(string text)
        {
            var searchTerms = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var query = _db.ProductList.AsQueryable();

            foreach (var term in searchTerms)
            {
                query = query.Where(x => x.ItemType.Model.Contains(term) || x.Name.Contains(term) || x.Price.ToString().Contains(term));
            }

            var results = await query.ToListAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(results);
        }

        public async Task<IEnumerable<ProductDTO>> SortByPrice(string type)
        {
            if (type == "ascending")
            {
                var results = await _db.ProductList.OrderBy(x => x.Price).ToListAsync();
                return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(results);
            }
            else if (type == "descending")
            {
                var results = await _db.ProductList.OrderByDescending(x => x.Price).ToListAsync();
                return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(results);
            }
            return new List<ProductDTO>();
        }

        public async Task<ProductDTO> Update(ProductDTO pDTO)
        {
            var obj = await _db.ProductList.FirstOrDefaultAsync(x => x.Id == pDTO.Id);
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
                obj.Section = pDTO.Section;
                _db.ProductList.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return pDTO;
        }

        public async Task<(IEnumerable<ProductDTO>, int)> GetBySectionAndItemType(string section, string itemType, int pageNumber, int pageSize)
        {
            var query = _db.ProductList.Include(x => x.ItemType).Include(x => x.Colors).Where(x => x.ItemType.Model == itemType && x.Section == section);

            int totalCount = await query.CountAsync();
            var products = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (_mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products), totalCount);
        }

        public async Task<IEnumerable<string>> GetSectionsForItemType(string itemTypeModel)
        {
            var productsThatIncludeSection = _db.ProductList.Where(x => x.ItemType.Model == itemTypeModel);

            var uniqueSections = productsThatIncludeSection.Select(x => x.Section)
                        .Distinct().Select(x => x);

            return uniqueSections.ToList();
        }
    }
}
