using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class SearchBlocoForIdPalavraSS
    {
        internal static string EncontraBlocoPorId(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT bloco FROM tbBlocos WHERE idBloco = @id";
            cm.Parameters.Add("id", System.Data.SqlDbType.VarChar).Value = id;
            cm.Connection = con;

            string blocoNome = "";
            SqlDataReader er;

            con.Open();
            try
            {
                // Executa a query, se o valor for > 0, ocorreu tudo certo
                er = cm.ExecuteReader();

                if (er.HasRows)
                {
                    while (er.Read())
                    {
                        blocoNome = Convert.ToString(er["bloco"]);
                    }
                }

            }
            catch (SqlException ex)
            {
                con.Close();
                throw ex;
            }
            con.Close();
            return blocoNome;
        }
    }
}
