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
    public class SizeService : ISizeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public SizeService(IMapper mapper, ApplicationDbContext db)
        {
            _db = db;
            _mapper = mapper;   
        }

        public async Task<SizeModelDTO> Create(SizeModelDTO wDto, int id)
        {
            wDto.ItemTypeModelId = id;
            var obj = _mapper.Map<SizeModelDTO, SizeModel>(wDto);

            var createdObj = _db.SizeList.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<SizeModel, SizeModelDTO>(createdObj.Entity);
        }

        public async Task<int> Delete(SizeModelDTO item)
        {
            var obj = await _db.SizeList.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (obj != null)
            {
                _db.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<SizeModelDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<SizeModel>, IEnumerable<SizeModelDTO>>(_db.SizeList);
        }

        public async Task<SizeModelDTO> GetById(int id)
        {
            var obj = await _db.SizeList.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<SizeModel, SizeModelDTO>(obj);
            }
            return new SizeModelDTO();
        }

        public async Task<SizeModelDTO> Update(SizeModelDTO wDto)
        {
            var obj = await _db.SizeList.FirstOrDefaultAsync(x => x.Id == wDto.Id);
            if ( obj != null)
            {
                obj.ItemSize = wDto.ItemSize;
                obj.IsAvailable = wDto.IsAvailable;
                _db.SizeList.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<SizeModel, SizeModelDTO>(obj);
            }
            return wDto;
        }
    }
}
