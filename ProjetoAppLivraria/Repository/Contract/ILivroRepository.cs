using ProjetoAppLivraria.Models;

namespace ProjetoAppLivraria.Repository.Contract
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> ObterTodosLivors();
        void Cadastrar(Livro livro);
        void Atualizar(Livro livro);
        Livro ObterLivro(Livro livro);
        void Excluir(int Id);
    }
}
