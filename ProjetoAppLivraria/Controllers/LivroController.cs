using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoAppLivraria.Models;
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
            var listaAutor = _autorRepository.ObterTodosAutoresAtivo();
            var ObjAutor = new Livro
            {
                idautor = (List<Autor>)listaAutor
            };
            ViewBag.ListaAutores = new SelectList(listaAutor, "idautor", "nameautor");
            return View();
        }
        [HttpPost]
        public IActionResult CadLivro(Livro livro)
        {
            var listarAutor = _autorRepository.ObterTodosAutoresAtivo();
            ViewBag.ListaAutores = new SelectList(listarAutor, "idautor", "nameautor");
            _livroRepository.Cadastrar(livro);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult editarLivro(int id)
        {
            var listaAutor = _autorRepository.ObterTodosAutoresAtivo();
            var ObjAutor = new Livro
            {
                idautor = (List<Autor>)listaAutor
            };
            ViewBag.ListaAutores = new SelectList(listaAutor, "idautor", "nameautor");
            return View(_livroRepository.ObterLivro(id));//Pode ser Utilizado com id
        }
        [HttpPost]
        public IActionResult editarLivro(Livro livro)
        {
            var listaAutor = _autorRepository.ObterTodosAutoresAtivo();
            ViewBag.ListaAutores = new SelectList(listaAutor, "idautor", "nameautor");
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
