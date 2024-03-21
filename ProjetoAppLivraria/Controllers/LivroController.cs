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

        public IActionResult editarLivro(int id)
        {
            var listaAutor = _autorRepository.ObterTodosAutores();
            var ObjAutor = new Livro
            {
                ListaAutor = (List<Autor>)listaAutor
            };
            ViewBag.ListaAutores = new SelectList(listaAutor, "Id", "nomeAutor");
            return View(_livroRepository.ObterLivro(id));//Pode ser Utilizado com id
        }
        [HttpPost]
        public IActionResult editarLivro(Livro livro)
        {
            var listaAutor = _autorRepository.ObterTodosAutores();
            ViewBag.ListaAutores = new SelectList(listaAutor, "Id", "nomeAutor");
            _livroRepository.Atualizar(livro);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int ID)
        {
            _livroRepository.Excluir(ID);
            return RedirectToAction(nameof(Index));
        }
    }
}
