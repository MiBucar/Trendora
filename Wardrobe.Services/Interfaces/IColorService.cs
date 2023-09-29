using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Services.Interfaces
{
    public interface IColorService
    {
        public Task<ColorDTO> GetById(int id);
        public Task<IEnumerable<ColorDTO>> GetAll();
        public Task<List<ColorDTO>> GetColorsByIds(List<int> colorIds);

    }
}
