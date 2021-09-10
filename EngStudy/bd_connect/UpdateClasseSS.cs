using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngStudy.bd_connect
{
    class UpdateClasseSS
    {
        // Classe para atualizar um registro na tabela Classe
        internal int atualizarRegistroDeClasse(classesDoDB.ClassesDto classeParaAtualizar)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "UPDATE Classe SET nome = @classe WHERE idClasse = @id";
            cm.Parameters.Add("id", System.Data.SqlDbType.Int).Value = classeParaAtualizar.idClasse;
            cm.Parameters.Add("classe", System.Data.SqlDbType.VarChar).Value = classeParaAtualizar.nome;
            cm.Connection = con;

            int resultado;

            try
            {
                // Executa a query, se o valor for > 0, ocorreu tudo certo
                con.Open();
                resultado = cm.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return resultado;


        }
    }
}
