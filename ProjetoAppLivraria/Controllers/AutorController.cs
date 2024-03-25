using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            return RedirectToAction(nameof(Index));
        }

        public IActionResult editarAutor(int id)
        {
            return View(_autorRepository.ObterAutor(id));//Pode ser Utilizado com id
        }
        [HttpPost]
        public IActionResult editarAutor(Autor autor)
        {
            ViewBag.ListaStatus = new SelectListItem("Sim", "Não");
            _autorRepository.Atualizar(autor);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int ID)
        {
            _autorRepository.Excluir(ID);
            return RedirectToAction(nameof(Index));
        }

    }
}
