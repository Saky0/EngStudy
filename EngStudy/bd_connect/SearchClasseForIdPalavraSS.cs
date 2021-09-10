using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class SearchClasseForIdPalavraSS
    {
        internal static string EncontraBlocoPorId(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT nome FROM Classe WHERE idClasse = @id";
            cm.Parameters.Add("id", System.Data.SqlDbType.VarChar).Value = id;
            cm.Connection = con;

            string classeNome = "";
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
                        classeNome = Convert.ToString(er["nome"]);
                    }
                }

            }
            catch (SqlException ex)
            {
                con.Close();
                throw ex;
            }
            con.Close();
            return classeNome;
        }
    }
}
