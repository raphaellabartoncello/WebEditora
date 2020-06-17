using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using Impacta.Editora.Model;
using System.Data;

namespace Impacta.Editora.DataADO
{
    public class EditoraDATA : IEditoraDATA
    {
        SqlConnection sqlConn = null;
        SqlCommand comandoSql = null;
        bool consult = false;
        string stringConexao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Editora;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Model.EditoraMOD GetEditora(int id)
        {
            throw new NotImplementedException();
        }

        public List<Model.EditoraMOD> GetList()
        {
            throw new NotImplementedException();
        }

        public bool Save(Model.EditoraMOD editora)
        {
            //Variável de controle para obter o resultado da execução da query
            int result = 0;

            try
            {
                sqlConn = new SqlConnection(stringConexao);

                comandoSql = new SqlCommand();

                comandoSql.CommandType = System.Data.CommandType.Text;
                comandoSql.CommandText = "INSERT INTO EDITORA(NOMEEDITORA, TELEFONE, EMAIL, OBSERVACOES) VALUES (@NomeEditora, @Telefone, @Email, @Observacoes)";
                comandoSql.Parameters.AddWithValue("@NomeEditora", editora.NomeEditora);
                comandoSql.Parameters.AddWithValue("@Telefone", editora.Telefone);
                comandoSql.Parameters.AddWithValue("@Email", editora.Email);
                comandoSql.Parameters.AddWithValue("@Observacoes", editora.Observacoes);

                comandoSql.Connection = sqlConn;

                sqlConn.Open();

                result = comandoSql.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }

            //Devolve um bool de resposta
            return result == 1 ? true : false;
        }

        public EditoraMOD Read(int id)
        {
            EditoraMOD editora = null;

            try
            {
                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoEditoraDB"].ConnectionString))
                {
                    comandoSql.Connection = conexao;

                    comandoSql.CommandType = CommandType.Text;

                    comandoSql.CommandText = @"SELECT EditoraId, NomeEditora, Telefone, Email, Observacoes FROM Editora WHERE EditoraId=@Id";

                    conexao.Open();

                    using (var dr = comandoSql.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            editora = new EditoraMOD()
                            {
                                Id = Convert.ToInt32(dr["EditoraId"]),
                                NomeEditora = Convert.ToString(dr["NomeEditora"]),
                                Telefone = Convert.ToString(dr["Telefone"]),
                                Email = Convert.ToString(dr["Email"]),
                                Observacoes = Convert.ToString(dr["Observacoes"]),

                            };
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return editora;
        }


        public List<EditoraMOD> ReadAll()
        {
            List<EditoraMOD> listaEditoras = new List<EditoraMOD>();

            try
            {
                //Verificar se o nome da conexão é de falto EditoraDB
                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoEditoraDB"].ConnectionString))
                {
                    comandoSql.Connection = conexao;

                    comandoSql.CommandType = CommandType.Text;

                    comandoSql.CommandText = "SELECT * FROM EDITORA ORDER BY NOMEEDITORA";

                    conexao.Open();

                    using (var dr = comandoSql.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var editora = new EditoraMOD();
                            editora.Id = Convert.ToInt32(dr["EditoraId"]);
                            editora.NomeEditora = Convert.ToString(dr["NomeEditora"]);
                            editora.Telefone = Convert.ToString(dr["Telefone"]);
                            editora.Email = Convert.ToString(dr["Email"]);
                            editora.Observacoes = Convert.ToString(dr["Observacoes"]);

                            listaEditoras.Add(editora);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaEditoras;
        }
    }
}