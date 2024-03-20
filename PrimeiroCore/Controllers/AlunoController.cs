using Microsoft.AspNetCore.Mvc;

namespace PrimeiroCore.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
