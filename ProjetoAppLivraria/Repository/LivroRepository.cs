using MySql.Data.MySqlClient;
using ProjetoAppLivraria.Models;
using ProjetoAppLivraria.Repository.Contract;
using System.Data;

namespace ProjetoAppLivraria.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly string _conexaoMySQL;
        public LivroRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Livro livro)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Livro livro)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tblivro (nomeLivro, codAutor) values (@nomeLivro, @codAutor)", conexao); //@: PARAMETRO

                cmd.Parameters.Add("@nomeLivro", MySqlDbType.VarChar).Value = livro.nomeLivro;
                cmd.Parameters.Add("@codAutor", MySqlDbType.VarChar).Value = livro.refAutor.Id;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Livro ObterLivro(Livro livro)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Livro> ObterTodosLivors()
        {
            List<Livro> Autlist = new List<Livro>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand command = new MySqlCommand("select * from tblivro as t1  " +
                    "INNER JOIN tbautor as t2 ON t1.codAutor = t2.codAutor;", conexao);
                MySqlDataAdapter db = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                db.Fill(dt);

                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    Autlist.Add(
                        new Livro
                        {
                            codLivro = Convert.ToInt32(dr["codLivro"]),
                            nomeLivro = (string)(dr["nomeLivro"]),
                            refAutor = new Autor()
                            {
                                Id = Convert.ToInt32(dr["codAutor"]),
                                nomeAutor = (string)(dr["nomeAutor"]),
                                status = Convert.ToString(dr["sta"]),
                            }
                        });
                }
                return Autlist;
            }
        }
    }
}
