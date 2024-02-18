using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Services.Interfaces
{
    public interface ICollectionService
    {
        public Task<CollectionDTO> CreateCollection(CollectionDTO collection);
        public Task<bool> DeleteCollection(CollectionDTO collection);
        public Task<IEnumerable<CollectionDTO>> GetAll();
        public Task<CollectionDTO> GetByName(string name);
    }
}
