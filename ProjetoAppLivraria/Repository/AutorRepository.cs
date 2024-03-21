using MySql.Data.MySqlClient;
using ProjetoAppLivraria.Models;
using ProjetoAppLivraria.Repository.Contract;
using System.Data;

namespace ProjetoAppLivraria.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly string _conexaoMySQL;

        public AutorRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Autor autor)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE tbautor SET nomeAutor=@nomeAutor, " +
                    "sta=@sta " +
                    "WHERE codAutor=@codAutor;", conexao);
                cmd.Parameters.Add("@codAutor", MySqlDbType.VarChar).Value = autor.Id;
                cmd.Parameters.Add("@nomeAutor", MySqlDbType.VarChar).Value = autor.nomeAutor;
                cmd.Parameters.Add("@sta", MySqlDbType.VarChar).Value = autor.status;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(Autor autor)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbautor (nomeAutor, sta) values (@nomeAutor, @sta)", conexao); //@: PARAMETRO

                cmd.Parameters.Add("@nomeAutor", MySqlDbType.VarChar).Value = autor.nomeAutor;
                cmd.Parameters.Add("@sta", MySqlDbType.VarChar).Value = autor.status;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from tbautor where codAutor=@codAutor", conexao);
                cmd.Parameters.AddWithValue("@codAutor", id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Autor ObterAutor(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbautor "+
                    " WHERE codAutor=@codAutor;", conexao);
                cmd.Parameters.AddWithValue("@codAutor", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Autor autor = new Autor();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    autor.Id = Convert.ToInt32(dr["codAutor"]);
                    autor.nomeAutor = (string)(dr["nomeAutor"]);
                    autor.status = Convert.ToString(dr["sta"]);
                }
                return autor;
            }
        }

        public IEnumerable<Autor> ObterTodosAutores()
        {
            List<Autor> Autlist = new List<Autor>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand command = new MySqlCommand("select * from tbautor;", conexao);
                MySqlDataAdapter db = new MySqlDataAdapter(command);

                DataTable dt = new DataTable();
                db.Fill(dt);

                conexao.Close();
                foreach(DataRow dr in dt.Rows)
                {
                    Autlist.Add(
                        new Autor
                        {
                            Id = Convert.ToInt32(dr["codAutor"]),
                            nomeAutor = (string)(dr["nomeAutor"]),
                            status =Convert.ToString(dr["sta"]),
                        });
                }
                return Autlist;
            }
        }
    }
}
