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
        public Task<ItemTypeModelDTO> Create(ItemTypeModelDTO item);
        public Task<ItemTypeModelDTO> Update(ItemTypeModelDTO item);
        public Task<int> Delete(int id);
        public Task<ItemTypeModelDTO> GetById(int id);
        public Task<IEnumerable<ItemTypeModelDTO>> GetAll();
    }
}
