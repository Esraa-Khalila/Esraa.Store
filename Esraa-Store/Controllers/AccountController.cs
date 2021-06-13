
using Esraa_Store.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var User = new IdentityUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.Phone };
                var r = await userManager.CreateAsync(User, model.Password);
                if (r.Succeeded)
                {
                    await signInManager.SignInAsync(User, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }
                foreach (var err in r.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }

            }
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (user.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Email/Password");
            }
            return View(model);


        }
 


    }
}
  
