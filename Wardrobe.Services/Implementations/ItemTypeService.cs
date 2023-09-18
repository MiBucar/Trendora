using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Data_Access;
using Wardrobe.Models.DTOs;
using Wardrobe.Models.Models;
using Wardrobe.Services.Interfaces;

namespace Wardrobe.Services.Implementations
{
    public class ItemTypeService : IItemTypeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ItemTypeService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ItemTypeModelDTO> Create(ItemTypeModelDTO item)
        {
            var obj = _mapper.Map<ItemTypeModelDTO, ItemTypeModel>(item);
            obj.DateCreated = DateTime.Now;

            var createdObj = _db.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<ItemTypeModel, ItemTypeModelDTO>(createdObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.ItemTypeList.FirstOrDefaultAsync(x => x.ItemTypeId == id);
            if (obj != null)
            {
                _db.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<ItemTypeModelDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ItemTypeModel>, IEnumerable<ItemTypeModelDTO>>(_db.ItemTypeList);
        }

        public async Task<ItemTypeModelDTO> GetById(int id)
        {
            var obj = await _db.ItemTypeList.FirstOrDefaultAsync(x => x.ItemTypeId == id);
            if (obj != null)
            {
                return _mapper.Map<ItemTypeModel, ItemTypeModelDTO>(obj);
            }
            return new ItemTypeModelDTO();
        }

        public async Task<ItemTypeModelDTO> Update(ItemTypeModelDTO item)
        {
            var obj = await _db.ItemTypeList.FirstOrDefaultAsync(x => x.ItemTypeId == item.ItemTypeId);
            if (obj != null)
            {
                obj.Model = item.Model;
                await _db.SaveChangesAsync();
                return _mapper.Map<ItemTypeModel, ItemTypeModelDTO>(obj);                
            }
            return item;
        }
    }
}
