﻿using AutoMapper;
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

            var tagIds = obj.Tags.Select(x => x.TagId).ToList();
            var existingTags = _db.TagList.Where(x => tagIds.Contains(x.TagId)).ToList();
            obj.Tags = existingTags;

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
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.ProductList.Include(x => x.Category).Include(x => x.Colors).Include(x => x.Tags));
        }

        public async Task<(IEnumerable<ProductDTO>, int)> GetByItemType(string itemType, int pageNumber, int pageSize)
        {
            var query = _db.ProductList.Include(x => x.Category).Include(x => x.Colors).Include(x => x.Tags).Where(x => x.Category.Name == itemType);

            int totalCount = await query.CountAsync();
            var products = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (_mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products), totalCount);
        }


        public async Task<ProductDTO> GetById(int id)
        {
            var obj = await _db.ProductList.Include(x => x.Category).Include(x => x.Colors).Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return new ProductDTO();
        }

        public async Task<ProductDTO> GetByGuid(Guid guid)
        {
            var obj = await _db.ProductList.Include(x => x.Category).Include(x => x.Colors).Include(x => x.Tags).FirstOrDefaultAsync(x => x.IdGuid == guid);
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
                query = query.Where(x => x.Category.Name.Contains(term) || x.Name.Contains(term) || x.Price.ToString().Contains(term));
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

                var tagIds = pDTO.Tags.Select(x => x.TagId).ToList();
                var existingTags = _db.TagList.Where(x => tagIds.Contains(x.TagId)).ToList();

                var genderId = pDTO.Gender.Id;
                var existingGender = _db.GenderList.FirstOrDefault(x => x.Id == genderId);

                obj.Colors = existingColors;
                obj.Tags = existingTags;
                obj.GenderId = pDTO.GenderId;
                obj.Name = pDTO.Name;
                obj.Description = pDTO.Description;
                obj.CategoryId = pDTO.CategoryId;
                obj.Price = pDTO.Price;
                obj.ImageData = pDTO.ImageData;
                obj.IdGuid = pDTO.IdGuid;
                obj.DateCreated = pDTO.DateCreated;
                _db.ProductList.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return pDTO;
        }

        public async Task<(IEnumerable<ProductDTO>, int)> GetByCollection(CollectionDTO collection, int pageNumber, int pageSize)
        {
            var collectionGenders = collection.Genders.Select(x => x.Name);
            var collectionTags = collection.Tags.Select(x => x.Title);

            var query = _db.ProductList.Include(x => x.Category).Include(x => x.Colors).Include(x => x.Tags).Where(x => collectionGenders.Contains(x.Gender.Name));

            if (collectionTags.Any())
            {
                var tempQuery = query.Where(x => x.Tags.Any(tag => collectionTags.Contains(tag.Title)));
                query = query.Union(tempQuery).Distinct();
            }

            int totalCount = await query.CountAsync();
            var products = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (_mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products), totalCount);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllByCollection(CollectionDTO collection)
        {
            var collectionGenders = collection.Genders.Select(x => x.Name);
            var collectionTags = collection.Tags.Select(x => x.Title);

            var query = _db.ProductList.Include(x => x.Category).Include(x => x.Colors).Include(x => x.Tags).Where(x => collectionGenders.Contains(x.Gender.Name));

            if (collectionTags.Any())
            {
                var tempQuery = query.Where(x => x.Tags.Any(tag => collectionTags.Contains(tag.Title)));
                query = query.Union(tempQuery).Distinct();
            }

            var products = query.ToList();

            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
        }

        public async Task<(IEnumerable<ProductDTO>, int)> GetByCollectionAndProducts(IEnumerable<ProductDTO> products, CollectionDTO collection, int pageNumber, int pageSize)
        {
            var collectionGenders = collection.Genders.Select(x => x.Name);
            var collectionTags = collection.Tags.Select(x => x.Title);

            var query = products;

            if (collectionTags.Any())
            {
                var tempQuery = query.Where(x => x.Tags.Any(tag => collectionTags.Contains(tag.Title)));
                query = query.Union(tempQuery).Distinct().ToList();
            }

            int totalCount = query.Count();
            var newProducts = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return (newProducts, totalCount);
        }

        public async Task<IEnumerable<string>> GetBrandsByCollection(CollectionDTO collection)
        {
            var gendersInCollection = collection.Genders.Select(x => x.Id);
            var tagsInCollection = collection.Tags.Select(x => x.TagId);

            var products = _db.ProductList.Where(x => gendersInCollection.Contains(x.Gender.Id));

            if (tagsInCollection.Any())
                products = products.Where(x => x.Tags.Any(tag => tagsInCollection.Contains(tag.TagId)));

            var uniqueBrands = products.Select(x => x.Name)
                        .Distinct().Select(x => x);

            return uniqueBrands;
        }
    }
}
