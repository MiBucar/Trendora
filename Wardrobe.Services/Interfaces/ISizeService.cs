using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Services.Interfaces
{
    public interface ISizeService
    {
        public Task<SizeModelDTO> Create(SizeModelDTO item, int id);
        public Task<int> Delete(SizeModelDTO item);
        public Task<SizeModelDTO> Update(SizeModelDTO item);
        public Task<SizeModelDTO> GetById(int id);
        public Task<IEnumerable<SizeModelDTO>> GetAll();
    }
}
