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
    public class TagService : ITagService
    {
        private readonly ApplicationDatabaseContext _db;
        private readonly IMapper _mapper;

        public TagService(ApplicationDatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TagDTO> CreateTag(TagDTO tag)
        {
            var obj = _mapper.Map<TagDTO, Tag>(tag);

            var createdObj = _db.Add(obj);
            await _db.SaveChangesAsync();

            var collection = await _db.CollectionList.Include(x => x.Tags).FirstOrDefaultAsync(y => y.CollectionId == 4);
            if (collection != null)
            {
                collection.Tags.Add(createdObj.Entity);
                await _db.SaveChangesAsync();
            }

            return _mapper.Map<Tag, TagDTO>(createdObj.Entity);
        }

        public async Task<bool> DeleteTag(TagDTO tag)
        {
            var obj = _db.TagList.FirstOrDefault(x => x.TagId == tag.TagId);
            if (obj != null)
            {
                var collection = await _db.CollectionList.Include(x => x.Tags).FirstOrDefaultAsync(y => y.CollectionId == 4);
                if (collection != null)
                {
                    if (collection.Tags.Contains(obj))
                        collection.Tags.Remove(obj);
                }

                _db.TagList.Remove(obj);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TagDTO>> GetAllTags()
        {
            return _mapper.Map<IEnumerable<Tag>, IEnumerable<TagDTO>>(_db.TagList);
        }
    }
}
