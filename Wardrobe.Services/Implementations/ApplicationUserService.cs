using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Common;
using Wardrobe.Data_Access;
using Wardrobe.Models.Models;
using Wardrobe.Services.Interfaces;

namespace Wardrobe.Services.Implementations
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDatabaseContext _db;
        private readonly AuthenticationStateProvider _authProvider;

        public ApplicationUserService(ApplicationDatabaseContext db, AuthenticationStateProvider authProvider)
        {
            _db = db;
            _authProvider = authProvider;
        }

        public async Task<bool> IsUserAdmin()
        {
            var authorizationState = await _authProvider.GetAuthenticationStateAsync();
            if (authorizationState?.User?.Identity?.Name == SD.Admin_Email)
                return true;
            return false;
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
