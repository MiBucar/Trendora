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
    public class CollectionService : ICollectionService
    {
        private readonly ApplicationDatabaseContext _db;
        private readonly IMapper _mapper;

        public CollectionService(ApplicationDatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CollectionDTO> CreateCollection(CollectionDTO collection)
        {
            var obj = _mapper.Map<CollectionDTO, Collection>(collection);

            var tagIds = obj.Tags.Select(x => x.TagId).ToList();
            var existingTags = _db.TagList.Where(x => tagIds.Contains(x.TagId)).ToList();
            obj.Tags = existingTags;

            var genderIds = obj.Genders.Select(x => x.Id).ToList();
            var existingGenders = _db.GenderList.Where(x => genderIds.Contains(x.Id)).ToList();
            obj.Genders = existingGenders;

            var createdObj = _db.CollectionList.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Collection, CollectionDTO>(obj);
        }

        public async Task<bool> DeleteCollection(CollectionDTO collection)
        {
            var obj = await _db.CollectionList.FirstOrDefaultAsync(x => x.CollectionId == collection.CollectionId);
            if (obj != null)
            {
                _db.Remove(obj);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CollectionDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Collection>, IEnumerable<CollectionDTO>>(_db.CollectionList.Include(x => x.Tags).Include(x => x.Genders));
        }

        public async Task<CollectionDTO> GetByName(string name)
        {
            var obj = await _db.CollectionList.Include(x => x.Tags).Include(x => x.Genders).FirstOrDefaultAsync(x => x.Name == name);
            if (obj != null)
                return _mapper.Map<Collection, CollectionDTO>(obj);

            return new CollectionDTO();
        }
    }
}
