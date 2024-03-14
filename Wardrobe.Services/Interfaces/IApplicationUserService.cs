using Wardrobe.Models.Models;

namespace Wardrobe.Services.Interfaces
{
    public interface IApplicationUserService
    {
        public Task<ApplicationUser> UpdateUser(ApplicationUser user);
        public Task<bool> IsUserAdmin();
    }
}
