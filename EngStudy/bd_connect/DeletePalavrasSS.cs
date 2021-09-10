using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class DeletePalavrasSS
    {
        internal static int ExcluirPalavra(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "DELETE tb_palavras WHERE id_palavra = @id";

            // Parametros
            cm.Parameters.Add("id", System.Data.SqlDbType.VarChar).Value = id;
         
            //
            cm.Connection = con;
            con.Open();
            int resultado = 0;

            try
            {
                resultado = cm.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                con.Close();
                throw ex;
            }

            return resultado;
        }
    }
}
