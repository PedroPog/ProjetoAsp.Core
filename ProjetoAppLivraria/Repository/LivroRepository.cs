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
            using(var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE livro_tb SET namelivro=@namelivro, " +
                    "idautor=@idautor " +
                    "WHERE idlivro=@idlivro;", conexao);
                cmd.Parameters.Add("@idlivro", MySqlDbType.VarChar).Value = livro.idlivro;
                cmd.Parameters.Add("@namelivro", MySqlDbType.VarChar).Value = livro.namelivro;
                cmd.Parameters.Add("@idautor", MySqlDbType.VarChar).Value = livro.refautor.idautor;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(Livro livro)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into livro_tb (namelivro, idautor) " +
                    "values (@namelivro, @idautor)", conexao); //@: PARAMETRO

                cmd.Parameters.Add("@namelivro", MySqlDbType.VarChar).Value = livro.namelivro;
                cmd.Parameters.Add("@idautor", MySqlDbType.VarChar).Value = livro.refautor.idautor;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int idlivro)
        {
            using(var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from livro_tb where idlivro=@idlivro",
                    conexao);
                cmd.Parameters.AddWithValue("@idlivro", idlivro);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }


        public Livro ObterLivro(int idlivro)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM livro_tb as t1 " +
                    "INNER JOIN autor_tb as t2 ON t1.idautor = t2.idautor WHERE idlivro=@idlivro;",
                    conexao);
                cmd.Parameters.AddWithValue("@idlivro", idlivro);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Livro livro = new Livro();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    livro.idlivro = Convert.ToInt32(dr["idlivro"]);
                    livro.namelivro = (string)(dr["namelivro"]);
                    livro.refautor = new Autor()
                    {
                        idautor = Convert.ToInt32(dr["idautor"]),
                        nameautor = (string)(dr["nameautor"]),
                        status = Convert.ToString(dr["status"])
                    };

                }
                return livro;

            }
        }

        public IEnumerable<Livro> ObterTodosLivors()
        {
            List<Livro> Autlist = new List<Livro>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand command = new MySqlCommand("select * from livro_tb as t1  "+
                    "INNER JOIN autor_tb as t2 ON t1.idautor = t2.idautor;", conexao);
                MySqlDataAdapter db = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                db.Fill(dt);

                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    Autlist.Add(
                        new Livro
                        {
                            idlivro = Convert.ToInt32(dr["idlivro"]),
                            namelivro = (string)(dr["namelivro"]),
                            refautor = new Autor()
                            {
                                idautor = Convert.ToInt32(dr["idautor"]),
                                nameautor = (string)(dr["nameautor"]),
                                status = Convert.ToString(dr["status"]),
                            }
                        });
                }
                return Autlist;
            }
        }
    }
}
