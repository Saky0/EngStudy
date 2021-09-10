using EngStudy.bd_connect.classesDoDB;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class CreatPalavrasSS
    {
        internal static int InserirPalavra(PalavrasDto palavraNova)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "INSERT INTO tb_Palavras (palavra, significado, pronuncia, " +
                "classe, fraseExemplo, blocoDePalavras) VALUES" +
                " (@palavra, @significado, @pronuncia, @classe, @fraseExemplo, @blocoDePalavras)";

            // Parametros
            cm.Parameters.Add("palavra", System.Data.SqlDbType.VarChar).Value = palavraNova.palavra;
            cm.Parameters.Add("significado", System.Data.SqlDbType.VarChar).Value = palavraNova.significado;
            cm.Parameters.Add("pronuncia", System.Data.SqlDbType.VarChar).Value = palavraNova.pronuncia;
            cm.Parameters.Add("classe", System.Data.SqlDbType.Int).Value = palavraNova.classe;
            cm.Parameters.Add("fraseExemplo", System.Data.SqlDbType.VarChar).Value = palavraNova.fraseExemplo;
            cm.Parameters.Add("blocoDePalavras", System.Data.SqlDbType.Int).Value = palavraNova.blocoDePalavras;

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
