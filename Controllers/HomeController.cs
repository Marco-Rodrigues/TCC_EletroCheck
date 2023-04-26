using EletroCheck.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EletroCheck.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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