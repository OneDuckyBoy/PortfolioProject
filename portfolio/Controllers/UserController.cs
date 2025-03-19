using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class UserController : Controller
    {

        private readonly IImageUploadService _imageUploadService;
        private readonly UserManager<User> _userManager;

        public readonly IService<Image> _imageService;
        // GET: UserController1
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: UserController1/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: UserController1/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: UserController1/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UserController1/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        public UserController(IImageUploadService imageUploadService, UserManager<User> userManager, IService<Image>imageService )
        {
            _imageUploadService = imageUploadService;
            _userManager = userManager;
            _imageService = imageService;
        }

        // POST: UserController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit1(int id, IFormCollection collection)
        {
             var user =  _userManager.FindByIdAsync(id.ToString());
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            if (model.Username != user.UserName)
            {
                var setUserNameResult = await _userManager.SetUserNameAsync(user, model.Username);
                if (!setUserNameResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Unexpected error when trying to set username.");
                    return View(model);
                }
            }

            if (model.PhoneNumber != user.PhoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Unexpected error when trying to set phone number.");
                    return View(model);
                }
            }

            if (model.ProfilePicture != null)
            {
                var imageUrl = await _imageUploadService.UploadImageAsync(model.ProfilePicture);
                user.ProfilePicture = new Image { Path = imageUrl };
                await _userManager.UpdateAsync(user);
            }

            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Edit), new { id = user.Id });
        }
        //// GET: UserController1/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UserController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
