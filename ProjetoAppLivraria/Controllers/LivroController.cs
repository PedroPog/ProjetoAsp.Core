using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoAppLivraria.Models;
using ProjetoAppLivraria.Repository;
using ProjetoAppLivraria.Repository.Contract;

namespace ProjetoAppLivraria.Controllers
{
    public class LivroController : Controller
    {
        private ILivroRepository _livroRepository;
        private IAutorRepository _autorRepository;

        public LivroController(ILivroRepository livroRepository,
            IAutorRepository autorRepository)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
        }
        public IActionResult Index()
        {
            return View(_livroRepository.ObterTodosLivors());
        }
        public IActionResult CadLivro()
        {
            var listaAutor = _autorRepository.ObterTodosAutores();
            var ObjAutor = new Livro
            {
                ListaAutor = (List<Autor>)listaAutor
            };
            ViewBag.ListaAutores = new SelectList(listaAutor, "Id", "nomeAutor");
            return View();
        }
        [HttpPost]
        public IActionResult CadLivro(Livro livro)
        {
            var listarAutor = _autorRepository.ObterTodosAutores();
            ViewBag.ListaAutores = new SelectList(listarAutor, "Id", "nomeAutor");
            _livroRepository.Cadastrar(livro);
            return RedirectToAction(nameof(Index));
        }
    }
}
