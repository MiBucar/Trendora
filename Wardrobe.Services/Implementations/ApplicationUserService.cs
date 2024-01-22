using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Data_Access;
using Wardrobe.Models.Models;
using Wardrobe.Services.Interfaces;

namespace Wardrobe.Services.Implementations
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDatabaseContext _db;

        public ApplicationUserService(ApplicationDatabaseContext db)
        {
            _db = db;
        }

        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            var existingUser = _db.UserList.FirstOrDefault(x => x.Id == user.Id);
            if (existingUser != null)
            {
                existingUser = user;
                await _db.SaveChangesAsync();
                return existingUser;
            }
            return new ApplicationUser();
        }
    }
}
