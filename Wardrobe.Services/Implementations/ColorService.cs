using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Data_Access;
using Wardrobe.Models.DTOs;
using Wardrobe.Models.Models;
using Wardrobe.Services.Interfaces;

namespace Wardrobe.Services.Implementations
{
    public class ColorService : IColorService
    {
        private readonly ApplicationDatabaseContext _db;
        private readonly IMapper _mapper;

        public ColorService(ApplicationDatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ColorDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Color>, IEnumerable<ColorDTO>>(_db.ColorList.Include(x => x.Products));
        }

        public async Task<ColorDTO> GetById(int id)
        {
            var obj = await _db.ColorList.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Color, ColorDTO>(obj);
            }
            return new ColorDTO();
        }

        public async Task<List<ColorDTO>> GetColorsByIds(List<int> colorIds)
        {
            var obj = await _db.ColorList.Where(c => colorIds.Contains(c.Id)).ToListAsync();
            return _mapper.Map<List<Color>, List<ColorDTO>>(obj);
        }

    }
}
