using EletroCheck.Context;
using EletroCheck.Models;
using EletroCheck.ViewsModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EletroCheck.Controllers
{

    public class UsuarioContaontroller : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        



        public UsuarioContaontroller(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;

        }


        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel registroVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registroVM.Email, };
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
public class UsuarioContaController : Controller

    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new UsuarioContaViewModel();
            return View(viewModel);
        }

             [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(UsuarioContaViewModel registroVM)
                            {
            if (ModelState.IsValid)
            {
                // Crie um novo objeto de usuário
                var user = new IdentityUser
                {
                    UserName = registroVM.Email,
                    PasswordHash = registroVM.Password,
                   

            };

                // Adicione o usuário ao banco de dados
                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    // Crie um novo objeto de conta de consumo
                    var conta = new CadastroContaConsumo
                    {
                        IdentificadorContaConsumo = registroVM.IdentificadorContaConsumo,
                        UrlIframePowerBI = registroVM.UrlIframePowerBI,
                        UserId = user.Id
                    };

                    // Adicione a conta de consumo ao banco de dados
                    _context.CadastroContaConsumo.Add(conta);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    // Lidar com erros de criação de usuário, se necessário
                }
            }

            return View(registroVM);
        }

    }
