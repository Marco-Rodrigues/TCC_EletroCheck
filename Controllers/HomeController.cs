using EletroCheck.Context;
using EletroCheck.Models;
using EletroCheck.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EletroCheck.Controllers
{

    public class HomeController : Controller

    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()

        {






            /* 
             * var usuarios = _context.Users.ToList();
             * var cadastroContas = _context.CadastroContaConsumo.ToList();

              var viewModelList = usuarios.Join(
                  cadastroContas,
                  u => u.UserName,
                  c => c.IdentificadorContaConsumo,
                  (u, c) => new CadastroContaConsumo
                  {
                      UserId = u.Id,
                      Email = u.Email,
                      IdentificadorContaConsumo = c.IdentificadorContaConsumo,

                                     }
              ).ToList();*/


            return View();
        }

        public IActionResult DadosPessoais() // Criando uma ação para a controller
    {
        return View(); // Retorna a View DadosPessoais.cshtml
    }


    public IActionResult login() // Criando uma ação para a controller
    {
        return View(); // Retorna a View DadosPessoais.cshtml
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}