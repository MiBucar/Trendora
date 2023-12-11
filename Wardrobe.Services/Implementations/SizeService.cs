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
        private readonly ApplicationDatabaseContext _db;
        private readonly IMapper _mapper;

        public SizeService(IMapper mapper, ApplicationDatabaseContext db)
        {
            _db = db;
            _mapper = mapper;   
        }

        public async Task<SizeDTO> Create(SizeDTO wDto, int id)
        {
            wDto.ItemTypeModelId = id;
            var obj = _mapper.Map<SizeDTO, Size>(wDto);

            var createdObj = _db.SizeList.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Size, SizeDTO>(createdObj.Entity);
        }

        public async Task<int> Delete(SizeDTO item)
        {
            var obj = await _db.SizeList.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (obj != null)
            {
                _db.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<SizeDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Size>, IEnumerable<SizeDTO>>(_db.SizeList);
        }

        public async Task<IEnumerable<SizeDTO>> GetAllOfId(int id)
        {
            return _mapper.Map<IEnumerable<Size>, IEnumerable<SizeDTO>>(_db.SizeList.Where(u => u.ItemTypeModelId == id));
        }

        public async Task<SizeDTO> GetById(int id)
        {
            var obj = await _db.SizeList.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Size, SizeDTO>(obj);
            }
            return new SizeDTO();
        }

        public async Task<SizeDTO> Update(SizeDTO wDto)
        {
            var obj = await _db.SizeList.FirstOrDefaultAsync(x => x.Id == wDto.Id);
            if ( obj != null)
            {
                obj.ItemSize = wDto.ItemSize;
                obj.IsAvailable = wDto.IsAvailable;
                _db.SizeList.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Size, SizeDTO>(obj);
            }
            return wDto;
        }
    }
}
