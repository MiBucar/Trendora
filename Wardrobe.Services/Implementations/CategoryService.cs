using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Data_Access;
using Wardrobe.Models.DTOs;
using Wardrobe.Models.Models;
using Wardrobe.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Wardrobe.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDatabaseContext _db;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO item)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(item);
            obj.DateCreated = DateTime.Now;

            var createdObj = _db.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDTO>(createdObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.CategoryList.FirstOrDefaultAsync(x => x.ItemTypeId == id);
            if (obj != null)
            {
                _db.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.CategoryList.Include(x => x.Sizes));
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var obj = await _db.CategoryList.Include(x => x.Sizes).FirstOrDefaultAsync(x => x.ItemTypeId == id);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<string>> GetModelsByIds(List<int> ids)
        {
            var newItemTypeList = new List<string>();
            foreach (var id in ids)
            {
                var obj = await _db.CategoryList.FirstOrDefaultAsync(x => x.ItemTypeId == id);
                if (obj != null)
                    newItemTypeList.Add(obj.Name);
            }
            return newItemTypeList;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesByCollection(CollectionDTO collection)
        {
            var genderIds = collection.Genders.Select(x => x.Id);
            var tagIds = collection.Tags.Select(x => x.TagId);

            var products = _db.ProductList.Where(x => genderIds.Contains(x.GenderId));

            if (tagIds.Any())
            {
                var tempQuery = products.Where(x => x.Tags.Any(tag => tagIds.Contains(tag.TagId)));
                products = products.Union(tempQuery).Distinct();
            }

            var uniqueCategories = products.Select(x => x.Category)
                        .Distinct().Select(x => x);
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(uniqueCategories);
        }

        public async Task<IEnumerable<CategoryDTO>> GetRandom(int num)
        {
            if (_db.CategoryList.Count() >= num)
            {
                var randomItems = _db.CategoryList.OrderBy(x => Guid.NewGuid()).Take(num).Include(x => x.Sizes);
                return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(randomItems);
            }
            return new List<CategoryDTO>();
        }

        public async Task<CategoryDTO> Update(CategoryDTO item)
        {
            var obj = await _db.CategoryList.FirstOrDefaultAsync(x => x.ItemTypeId == item.ItemTypeId);
            if (obj != null)
            {
                obj.Name = item.Name;
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(obj);                
            }
            return item;
        }
    }
}
