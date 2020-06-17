﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Impacta.Editora.DataADO
{
    public class EditoraDATA: IEditoraDATA
    {
        SqlConnection sqlConn = null;
        SqlCommand comandoSql = null;
        string stringConexao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IMPACTA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Model.Editora GetEditora(int id)
        {
            throw new NotImplementedException();
        }

        public List<Model.Editora> GetList()
        {
            throw new NotImplementedException();
        }

        public bool Save(Model.Editora editora)
        {
            //Variável de controle para obter o resultado da execução da query
            int result = 0;

            try
            {
                sqlConn = new SqlConnection(stringConexao);

                comandoSql = new SqlCommand();

                comandoSql.CommandType = System.Data.CommandType.Text;
                comandoSql.CommandText = "INSERT INTO EDITORA(NOME, TELEFONE, EMAIL, OBSERVACOES) VALUES (@Nome, @Tel, @Email, @Obs)";
                comandoSql.Parameters.AddWithValue("@Nome", editora.Nome);
                comandoSql.Parameters.AddWithValue("@Tel", editora.Telefone);
                comandoSql.Parameters.AddWithValue("@Email", editora.Email);
                comandoSql.Parameters.AddWithValue("@Obs", editora.Observacoes);

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
    }
}