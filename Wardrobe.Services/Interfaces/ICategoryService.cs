using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<CategoryDTO> Create(CategoryDTO item);
        public Task<CategoryDTO> Update(CategoryDTO item);
        public Task<int> Delete(int id);
        public Task<CategoryDTO> GetById(int id);
        public Task<IEnumerable<CategoryDTO>> GetAll();
        public Task<IEnumerable<CategoryDTO>> GetRandom(int num);
        public Task<IEnumerable<string>> GetModelsByIds(List<int> ids);
        public Task<IEnumerable<CategoryDTO>> GetCategoriesByCollection(CollectionDTO collection);
    }
}
