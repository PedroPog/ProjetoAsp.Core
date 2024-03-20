using Microsoft.AspNetCore.Mvc;
using ProjetoAppLivraria.Models;
using ProjetoAppLivraria.Repository;
using ProjetoAppLivraria.Repository.Contract;

namespace ProjetoAppLivraria.Controllers
{
    public class AutorController : Controller
    {
        private IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public IActionResult Index()
        {
            return View(_autorRepository.ObterTodosAutores());
        }
        public IActionResult CadAutor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadAutor(Autor autor)
        {
            _autorRepository.Cadastrar(autor);
            return View();
        }


    }
}
