using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OdeToFoodTutorial.Entities;
using OdeToFoodTutorial.ViewModels;
using System.Threading.Tasks;

namespace OdeToFoodTutorial.Controllers
{
    public class AccountController : Controller
    {
		private UserManager<User> _userManager;
		private SignInManager<User> _signInManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterUserViewModel model)
		{
			if (!ModelState.IsValid)
				return View();

			var user = new User
			{
				UserName = model.Username
			};

			var createResult = await _userManager.CreateAsync(user, model.Password);
			if (createResult.Succeeded)
			{
				await _signInManager.SignInAsync(user, false);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				foreach (var error in createResult.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View();
			}
		}
    }
}
