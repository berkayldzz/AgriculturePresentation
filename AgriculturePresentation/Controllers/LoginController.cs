using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var result=await _signInManager.PasswordSignInAsync(loginViewModel.username,loginViewModel.password,false,false);
               
                if(result.Succeeded) 
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }


            return View();
        }

        // Kayıt işlemi gerçekleştirme

        [HttpGet]

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Signup(RegisterViewModel registerViewModel)
        {
            // Kayıt işlemi gerçekleştirme

            IdentityUser ıdentityUser = new IdentityUser()
            {
                Id = "1", // id otomatik artan olmadığı için başta 1 verdik.
                UserName = registerViewModel.userName,
                Email = registerViewModel.mail
            };
            if (registerViewModel.password == registerViewModel.passwordConfirm)
            {
                var result = await _userManager.CreateAsync(ıdentityUser, registerViewModel.password);


                if (result.Succeeded) // Eğer ki yukarıdaki işlemler başarılıysa
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description); // Hatamızı göstersin.
                    }
                }
            }


            return View(registerViewModel);
        }


    }
}
