using EletroCheck.Context;
using EletroCheck.ViewsModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EletroCheck.Controllers
{

    public class AccountController : Controller
    {
        //private readonly UserManager<IdentityUser> _userManager;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly SignInManager<IdentityUser> _signInManager;


        // public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)

        {
            this._userManager = userManager;
            this._signInManager = signInManager;

        }


        //public IActionResult Index()
        //{
        //    var usuarios = _userManager.Users.ToList();
        //    return View(usuarios);
        //}



        public IActionResult Login(string returnUrl)

        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {

                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);


                if (result.Succeeded)

                {
                    var informacoesUrlPowerBi = await _userManager.Users
                   .Where(e => e.UserName == user.UserName)
                   .Select(e => e.UrlPowerBi)
                   .FirstOrDefaultAsync();
                            // Utilize a informação para montar o iframe
                  
                    string url = informacoesUrlPowerBi;
                    

                   // string iframeHtml = $"<iframe src=\"{url}\" width=\"100%\" height=\"541.25\"></iframe>";

                    // Passe o iframeHtml para a view
                    TempData["url"] = url;
                   // ViewBag.IframeHtml = iframeHtml;

                    
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {

                        return RedirectToAction("Index", "Home");
                    }

                    return Redirect(loginVM.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Falha ao realizar o login!");
            return View(loginVM);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registroVM)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = registroVM.Email, };

                //var user = new IdentityUser { UserName = registroVM.Email, };
                //var user = new CadastroViewModel { UserName = registroVM.UserName };

                var result = await _userManager.CreateAsync(user, registroVM.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Login", "Account");
                }

            }
            else
            {
                this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
            }

            return View(registroVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


    }
}
