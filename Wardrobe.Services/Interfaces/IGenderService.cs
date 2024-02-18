using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.DTOs;

namespace Wardrobe.Services.Interfaces
{
    public interface IGenderService
    {
        public Task<IEnumerable<GenderDTO>> GetAll();
    }
}
