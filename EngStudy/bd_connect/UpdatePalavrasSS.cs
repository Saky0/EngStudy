using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EngStudy.bd_connect.classesDoDB;

namespace EngStudy.bd_connect
{
    class UpdatePalavrasSS
    {
        internal static int atualizarRegistroDePalavras(PalavrasDto palavraUpdate)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "UPDATE tb_Palavras SET palavra = @palavra, significado = @significado, pronuncia = @pronuncia, " +
                "classe = @classe, fraseExemplo = @fraseExemplo, blocoDePalavras = @blocoDePalavras " +
                "WHERE idPalavra = @id";

            // Parametros
            cm.Parameters.Add("palavra", System.Data.SqlDbType.VarChar).Value = palavraUpdate.palavra;
            cm.Parameters.Add("significado", System.Data.SqlDbType.VarChar).Value = palavraUpdate.significado;
            cm.Parameters.Add("significado", System.Data.SqlDbType.VarChar).Value = palavraUpdate.significado;
            cm.Parameters.Add("classe", System.Data.SqlDbType.VarChar).Value = palavraUpdate.classe;
            cm.Parameters.Add("fraseExemplo", System.Data.SqlDbType.VarChar).Value = palavraUpdate.fraseExemplo;
            cm.Parameters.Add("blocoDePalavras", System.Data.SqlDbType.VarChar).Value = palavraUpdate.blocoDePalavras;
            cm.Parameters.Add("id", System.Data.SqlDbType.VarChar).Value = palavraUpdate.idPalavra;

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
