using AutoMapper;
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
    public class GenderService : IGenderService
    {
        private readonly ApplicationDatabaseContext _db;
        private readonly IMapper _mapper;

        public GenderService(ApplicationDatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenderDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Gender>, IEnumerable<GenderDTO>>(_db.GenderList);
        }
    }
}
