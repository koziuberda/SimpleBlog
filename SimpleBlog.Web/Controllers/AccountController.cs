using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Entities;
using SimpleBlog.Web.Models;

namespace SimpleBlog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        // GET
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel{ReturnUrl = returnUrl});
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, true, false);
                Console.WriteLine(result.Succeeded);
                if (result.Succeeded)
                {
                    return LocalRedirect(viewModel.ReturnUrl ?? "/");
                }
                
                ModelState.AddModelError("", "Invalid username or password");
            }
            
            return View(viewModel);
        }
        
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("/");
        }
    }
}