using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Services.Interfaces
{
    public interface IItemTypeService
    {
        public Task<ItemTypeDTO> Create(ItemTypeDTO item);
        public Task<ItemTypeDTO> Update(ItemTypeDTO item);
        public Task<int> Delete(int id);
        public Task<ItemTypeDTO> GetById(int id);
        public Task<IEnumerable<ItemTypeDTO>> GetAll();
        public Task<IEnumerable<ItemTypeDTO>> GetRandom(int num);
        public Task<IEnumerable<string>> GetModelsByIds(List<int> ids);
        public Task<IEnumerable<ItemTypeDTO>> GetModelsBySection(string section);
    }
}
