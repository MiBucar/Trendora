using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using Wardrobe.Models.Models;

namespace Wardrobe.Areas.Identity.Pages.Account
{
    public class InputModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class GuestModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class UserCheckoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IMemoryCache _cache;

        public UserCheckoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, IMemoryCache cache)
        {
            _signInManager = signInManager;
            _logger = logger;
            _cache = cache;
        }

        [BindProperty(Name = "GuestInput")]
        public GuestModel GuestInput { get; set; }

        [BindProperty(Name = "LoginInput")]
        public InputModel LoginInput { get; set; }

        public bool IsGuestCheckout { get; set; }
        public string ReturnUrl { get; set; }
        public string ErrorMessage { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            var test = HttpContext.Session.GetString("guest");

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            ReturnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ModelState.ClearValidationState(nameof(GuestInput));
            if (!TryValidateModel(LoginInput, nameof(LoginInput)))
            {
                var result = await _signInManager.PasswordSignInAsync(LoginInput.Email, LoginInput.Password, LoginInput.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(ReturnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = ReturnUrl, RememberMe = LoginInput.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostContinueAsGuestAsync()
        {
            ModelState.ClearValidationState(nameof(LoginInput));
            if (!TryValidateModel(GuestInput, nameof(GuestInput)))
            {
                //HttpContext.Session.SetString("guest", GuestInput.Email);
                //await HttpContext.Session.CommitAsync();
                var cacheEntryOption = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));
                _cache.Set("guest", GuestInput.Email, cacheEntryOption);
                return LocalRedirect("/ShoppingCart");
            }
            return Page();
        }
    }
}
