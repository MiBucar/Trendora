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
        public Task<SizeDTO> Create(SizeDTO item, int id);
        public Task<int> Delete(SizeDTO item);
        public Task<SizeDTO> Update(SizeDTO item);
        public Task<SizeDTO> GetById(int id);
        public Task<IEnumerable<SizeDTO>> GetAll();
        public Task<IEnumerable<SizeDTO>> GetAllOfId(int id);
    }
}
