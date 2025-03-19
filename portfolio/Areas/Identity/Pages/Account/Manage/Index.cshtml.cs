using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Portfolio.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IImageUploadService _imageUploadService;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IImageUploadService imageUploadService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _imageUploadService = imageUploadService;
        }

        [BindProperty]
        public ProfileViewModel Input { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;
            Email = email;
            ProfilePictureUrl = user.ProfilePicture?.Path ?? "/images/default-profile.png";

            Input = new ProfileViewModel
            {
                Username = userName,
                Email = email,
                PhoneNumber = phoneNumber,
                ProfilePictureUrl = ProfilePictureUrl
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.Users
                .Include(u => u.ProfilePicture)
                .FirstOrDefaultAsync(u => u.Id == int.Parse(_userManager.GetUserId(User)));

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.Users
                .Include(u => u.ProfilePicture)
                .FirstOrDefaultAsync(u => u.Id == int.Parse(_userManager.GetUserId(User)));

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //if (!ModelState.IsValid)
            //{
            //    await LoadAsync(user);
            //    return Page();
            //}
            if (string.IsNullOrWhiteSpace(Input.Username))
            {
                ModelState.AddModelError("Input.Username", "Username is required.");
            }

            //if (string.IsNullOrWhiteSpace(Input.Email) || !new EmailAddressAttribute().IsValid(Input.Email))
            //{
            //    ModelState.AddModelError("Input.Email", "A valid email is required.");
            //}

            if (string.IsNullOrWhiteSpace(Input.PhoneNumber) || !new PhoneAttribute().IsValid(Input.PhoneNumber))
            {
                ModelState.AddModelError("Input.PhoneNumber", "A valid phone number is required.");
            }

            if (Input.Username != user.UserName)
            {
                var setUserNameResult = await _userManager.SetUserNameAsync(user, Input.Username);
                if (!setUserNameResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set username.";
                    return RedirectToPage();
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (Input.ProfilePicture != null)
            {
                var imageUrl = await _imageUploadService.UploadImageAsync(Input.ProfilePicture);
                user.ProfilePicture = new Image { Path = imageUrl };
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
