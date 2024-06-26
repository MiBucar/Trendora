﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDTO> Create(ProductDTO pDTO);
        public Task<ProductDTO> Update(ProductDTO pDTO);
        public Task<int> Delete(int id);
        public Task<ProductDTO> GetById(int id);
        public Task<ProductDTO> GetByGuid(Guid guid);
        public Task<IEnumerable<ProductDTO>> GetAll();
        public Task<IEnumerable<ProductDTO>> SearchByText(string text);
        public Task<IEnumerable<ProductDTO>> SortByPrice(string type);
        public Task<(IEnumerable<ProductDTO>, int)> GetByItemType(string category, int pageNumber, int pageSize);
        public Task<(IEnumerable<ProductDTO>, int)> GetByCollection(CollectionDTO collection, int pageNumber, int pageSize);
        public Task<(IEnumerable<ProductDTO>, int)> GetByCollectionAndProducts(IEnumerable<ProductDTO> products, CollectionDTO collection, int pageNumber, int pageSize);
        public Task<IEnumerable<ProductDTO>> GetAllByCollection(CollectionDTO collection);
        public Task<IEnumerable<string>> GetBrandsByCollection(CollectionDTO collection);
    }
}
