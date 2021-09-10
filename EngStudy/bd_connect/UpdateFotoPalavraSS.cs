using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class UpdateFotoPalavraSS
    {
        internal static int AtualizarFotoEmPalavra(string caminhoFoto, int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "UPDATE tb_palavras SET fotoExemplo = @caminho WHERE id_palavra = @id";

            // Parametros
            cm.Parameters.Add("caminho", System.Data.SqlDbType.VarChar).Value = caminhoFoto;
            cm.Parameters.Add("id", System.Data.SqlDbType.Int).Value = id;

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

            con.Close();
            return resultado;
        }
    }
}
