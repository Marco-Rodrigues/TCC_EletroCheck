using EletroCheck.Context;
using EletroCheck.Models;
using EletroCheck.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EletroCheck.Controllers
{

    public class AccountController : Controller
    {


        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)

        {
            this._userManager = userManager;
            this._signInManager = signInManager;

        }



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

                    var userQuery = _userManager.Users.Where(e => e.UserName == user.UserName);

                    var userInfo = await userQuery.Select(e => new
                    {
                        UrlPowerBi = e.UrlPowerBi,
                        FirstName = e.FirstName,
                        UsuarioAdministrador = e.UsuárioAdministrador
                    }).FirstOrDefaultAsync();

                    string url = userInfo?.UrlPowerBi;
                    string nome = userInfo?.FirstName;
                    bool isAdministrativo = userInfo?.UsuarioAdministrador ?? false;

                    TempData["url"] = url;
                    ViewBag.Nome = nome;
                    TempData["firstName"] = nome;
                    TempData["IsAdministrativo"] = isAdministrativo;


                    bool issAdministrativo = user.UsuárioAdministrador;

                    if (issAdministrativo)
                    {
                        return RedirectToAction("UsersAdmin", "Account");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        return Redirect(loginVM.ReturnUrl);
                    }


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
                var user = new ApplicationUser { UserName = registroVM.Email, FirstName = registroVM.FirstName, LastName = registroVM.LastName };


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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("Login");
        }

        [Authorize]
        public async Task<IActionResult> UsersAdmin()
        {
            var users = await _userManager.Users.ToListAsync(); // Obtém todos os usuários
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Obtém o ID do usuário atualmente logado
            var user = await _userManager.FindByIdAsync(userId); // Obtém o objeto do usuário com base no ID

            ViewBag.Users = users;
            ViewBag.CurrentUserFirstName = user.FirstName; // Substitua "FirstName" pelo nome correto da propriedade que você criou
            ViewBag.UsuárioAdministrador = user.UsuárioAdministrador;
            return View(users);
        }


        public IActionResult EditUser(string id)
        {

            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);



            if (user == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                UrlPowerBi = user.UrlPowerBi,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(string id, EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditUser", model);
            }

            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;
            user.UrlPowerBi = model.UrlPowerBi;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Falha ao salvar as alterações do usuário.");
                return View("EditUser", model);
            }

            return RedirectToAction("UsersAdmin");
        }

        [HttpPost]
        public IActionResult DeleteUser(string id)
        {
            // Localizar o usuário no banco de dados com base no ID fornecido
            var user = _userManager.FindByIdAsync(id).Result;

            if (user == null)
            {
                // Usuário não encontrado, retorne uma resposta adequada, como uma página de erro ou redirecionamento
                return NotFound("Error");
            }

            // Remover o usuário do banco de dados
            var result = _userManager.DeleteAsync(user).Result;


            if (result.Succeeded)
            {
                // Usuário excluído com sucesso, redirecionar para a página de listagem de usuários ou uma página de confirmação
                return RedirectToAction("UsersAdmin");
            }
            else
            {
                // Ocorreu um erro ao excluir o usuário, trate o erro conforme necessário
                // Você pode adicionar erros ao ModelState e exibi-los na view de edição de usuário
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                // Retorne a view de edição de usuário com os erros
                return View("EditUser", new EditUserViewModel { UserId = id });
            }
        }
    }
}
