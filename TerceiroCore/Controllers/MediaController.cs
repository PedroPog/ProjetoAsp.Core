using Microsoft.AspNetCore.Mvc;
using TerceiroCore.Models;
using TerceiroCore.Models.Dados;

namespace TerceiroCore.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        AcoesMedia am = new AcoesMedia();
        [HttpPost]
        public ActionResult Index(ModelMedia frm)
        {
            var soma = am.CalcularSoma(frm);
            var media = am.CalcularMedia(frm);

            ViewBag.soma = "A Soma dos Meses é: " +soma;

            ViewBag.media = "A Media dos mesmes é: " + media;

            if (soma >= 300 && soma <= 499)
            {
                ViewBag.res = "Nota atingida";
            }
            if (soma >= 500)
            {
                ViewBag.res = "Nota superada";
            }
            else
            {
                ViewBag.res = "Nota não atigida";
            }
            return View();
        }
    }
}
