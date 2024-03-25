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
                MySqlCommand cmd = new MySqlCommand("UPDATE autor_tb SET nameautor=@nameautor, "+
                    "status=@status "+
                    "WHERE idautor=@idautor;", conexao);
                cmd.Parameters.Add("@idautor", MySqlDbType.VarChar).Value = autor.idautor;
                cmd.Parameters.Add("@nameautor", MySqlDbType.VarChar).Value = autor.nameautor;
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = autor.status;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(Autor autor)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into autor_tb (nameautor, status) " +
                    "values (@nameautor, @status)", conexao); //@: PARAMETRO

                cmd.Parameters.Add("@nameautor", MySqlDbType.VarChar).Value = autor.nameautor;
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = autor.status;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int idautor)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from autor_tb where "+
                    "idautor=@idautor", conexao);
                cmd.Parameters.AddWithValue("@idautor", idautor);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Autor ObterAutor(int idautor)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM autor_tb " +
                    " WHERE idautor=@idautor;", conexao);
                cmd.Parameters.AddWithValue("@idautor", idautor);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Autor autor = new Autor();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    autor.idautor = Convert.ToInt32(dr["idautor"]);
                    autor.nameautor = (string)(dr["nameautor"]);
                    autor.status = Convert.ToString(dr["status"]);
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
                MySqlCommand command = new MySqlCommand("select * from autor_tb;", conexao);
                MySqlDataAdapter db = new MySqlDataAdapter(command);

                DataTable dt = new DataTable();
                db.Fill(dt);

                conexao.Close();
                foreach(DataRow dr in dt.Rows)
                {
                    Autlist.Add(
                        new Autor
                        {
                            idautor = Convert.ToInt32(dr["idautor"]),
                            nameautor = (string)(dr["nameautor"]),
                            status = Convert.ToString(dr["status"]),
                        });
                }
                return Autlist;
            }
        }
        public IEnumerable<Autor> ObterTodosAutoresAtivo()
        {
            List<Autor> Autlist = new List<Autor>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand command = new MySqlCommand("select * from autor_tb WHERE status = '1';", conexao);
                MySqlDataAdapter db = new MySqlDataAdapter(command);

                DataTable dt = new DataTable();
                db.Fill(dt);

                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    Autlist.Add(
                        new Autor
                        {
                            idautor = Convert.ToInt32(dr["idautor"]),
                            nameautor = (string)(dr["nameautor"]),
                            status = Convert.ToString(dr["status"]),
                        });
                }
                return Autlist;
            }
        }
    }
}
