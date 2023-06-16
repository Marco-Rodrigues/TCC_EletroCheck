using Microsoft.AspNetCore.Mvc;

namespace EletroCheck.Controllers
{
    public class CadastroGeralController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
