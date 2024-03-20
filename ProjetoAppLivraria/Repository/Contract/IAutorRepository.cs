using ProjetoAppLivraria.Models;

namespace ProjetoAppLivraria.Repository.Contract
{
    public interface IAutorRepository
    {

        //CRUD
        IEnumerable<Autor> ObterTodosAutores();

        void Cadastrar(Autor autor);
        void Atualizar(Autor autor);
        Autor ObterAutor(int Id);
        void Excluir(int id);
    }
}
