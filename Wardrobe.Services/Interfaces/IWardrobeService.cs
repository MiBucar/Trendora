using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Services.Interfaces
{
    public interface IWardrobeService
    {
        public Task<WardrobeDTO> Create(WardrobeDTO wDto);
        public Task<WardrobeDTO> Update(WardrobeDTO wDto);
        public Task<int> Delete(int id);
        public Task<WardrobeDTO> GetById(int id);
        public Task<IEnumerable<WardrobeDTO>> GetAll();
        public Task<IEnumerable<WardrobeDTO>> SearchByText(string text);
        public Task<IEnumerable<WardrobeDTO>> SortByPrice(string type);
    }
}
