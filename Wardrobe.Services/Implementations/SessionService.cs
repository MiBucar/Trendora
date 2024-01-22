using Microsoft.AspNetCore.Http;
using Wardrobe.Services.Interfaces;

namespace Wardrobe.Services.Implementations
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetGuestMail()
        {
            throw new NotImplementedException();
        }

        public void SetGuestMail(string guestMail)
        {
        }
    }
}
