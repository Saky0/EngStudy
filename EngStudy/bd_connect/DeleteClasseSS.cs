using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class DeleteClasseSS
    {
        // Deleta um registro na tabela Classe
        internal int deletarClasseExistente(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "DELETE Classe WHERE idClasse = @id";
            cm.Parameters.Add("id", System.Data.SqlDbType.Int).Value = id;
            cm.Connection = con;
            int resultado;
            con.Open();

            try
            {
                // Executa a query, se o valor for > 0, ocorreu tudo certo
                
                resultado = cm.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                con.Close();
                throw ex;
            }
            con.Close();
            return resultado;
        }
    }
}
