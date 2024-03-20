using Microsoft.AspNetCore.Mvc;

namespace SegundoCore.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection frm)
        {
            Console.WriteLine("Teste");
            double N1, N2, N3, N4, Soma, Media;
            N1 = double.Parse(frm["txtJan"]);
            N2 = double.Parse(frm["txtFev"]);
            N3 = double.Parse(frm["txtMar"]);
            N4 = double.Parse(frm["txtAbr"]);

            Soma = N1 + N2 + N3 + N4;
            Media = Soma / 4;

            ViewBag.soma = "A Soma é: " + Soma;
            ViewBag.media = "A Soma é: " + Media;

            if(Media >= 300 && Media <= 499)
            {
                ViewBag.res = "Nota atingida";
            }
            if(Media >= 500)
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
