﻿using AutoMapper;
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
    public class WardrobeService : IWardrobeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public WardrobeService(IMapper mapper, ApplicationDbContext db)
        {
            _db = db;
            _mapper = mapper;   
        }

        public async Task<WardrobeDTO> Create(WardrobeDTO wDto)
        {
            var obj = _mapper.Map<WardrobeDTO, WardrobeModel>(wDto);
            obj.DateCreated = DateTime.Now;

            var createdObj = _db.WardrobeList.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<WardrobeModel, WardrobeDTO>(createdObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.WardrobeList.Include(x => x.ItemType).FirstOrDefaultAsync(x => x.WardrobeModelId == id);
            if (obj != null)
            {
                _db.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<WardrobeDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<WardrobeModel>, IEnumerable<WardrobeDTO>>(_db.WardrobeList.Include(x => x.ItemType));
        }

        public async Task<WardrobeDTO> GetById(int id)
        {
            var obj = await _db.WardrobeList.FirstOrDefaultAsync(x => x.WardrobeModelId == id);
            if (obj != null)
            {
                return _mapper.Map<WardrobeModel, WardrobeDTO>(obj);
            }
            return new WardrobeDTO();
        }

        public async Task<IEnumerable<WardrobeDTO>> SearchByText(string text)
        {
            var searchTerms = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var query = _db.WardrobeList.AsQueryable();

            foreach (var term in searchTerms)
            {
                query = query.Where(x => x.Color.Contains(term) || x.ItemType.Model.Contains(term));
            }

            var results = await query.ToListAsync();
            return _mapper.Map<IEnumerable<WardrobeModel>, IEnumerable<WardrobeDTO>>(results);
        }

        public async Task<WardrobeDTO> Update(WardrobeDTO wDto)
        {
            var obj = await _db.WardrobeList.FirstOrDefaultAsync(x => x.WardrobeModelId == wDto.WardrobeModelId);
            if ( obj != null)
            {
                obj.ItemTypeModelId = wDto.WardrobeModelId;
                obj.Price = wDto.Price;
                obj.Color = wDto.Color;
                obj.ImageData = wDto.ImageData;
                await _db.SaveChangesAsync();
                return _mapper.Map<WardrobeModel, WardrobeDTO>(obj);
            }
            return wDto;
        }
    }
}
