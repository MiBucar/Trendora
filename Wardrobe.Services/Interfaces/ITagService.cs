using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Services.Interfaces
{
    public interface ITagService
    {
        public Task<TagDTO> CreateTag(TagDTO tag);
        public Task<bool> DeleteTag(TagDTO tag);
        public Task<IEnumerable<TagDTO>> GetAllTags();
    }
}
