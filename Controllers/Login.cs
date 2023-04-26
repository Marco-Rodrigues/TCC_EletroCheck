using Microsoft.AspNetCore.Mvc;

namespace EletroCheck.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
