﻿using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ProfileController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); // Ada göre değeri bul

            UserEditViewModel userEditViewModel = new UserEditViewModel();

            // Şifre bu kısımda yazılan bir ifade değil.

            userEditViewModel.Mail = values.Email;
            userEditViewModel.Phone = values.PhoneNumber;

            return View(userEditViewModel);
        }

        // Güncelleme kısmı

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); // Ada göre değeri bul
            if (p.Password == p.ConfirmPassword)
            {

                values.Email = p.Mail;
                values.PhoneNumber = p.Phone;
                // Şifreleme farklı
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);

                var result=await _userManager.UpdateAsync(values);  
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
            }
            return View();

        }
    }
}
