using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngStudy.bd_connect.classesDoDB;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class SearchIdClasseForNameParaPalavraSS
    {
        internal static int EncontraIdClasseCorrespondente(string classe)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT idClasse FROM Classe WHERE nome = @classe";
            cm.Parameters.Add("classe", System.Data.SqlDbType.VarChar).Value = classe;
            cm.Connection = con;

            int idEncontrado = 0;

            SqlDataReader er;

            con.Open();
            try
            {
                // Executa a query, se o valor for > 0, ocorreu tudo certo
                er = cm.ExecuteReader();

                if(er.HasRows)
                {
                    while(er.Read())
                    {
                        idEncontrado = Convert.ToInt32(er["idClasse"]);
                    }
                }

            }
            catch (SqlException ex)
            {
                con.Close();
                throw ex;
            }
            con.Close();
            return idEncontrado;
        }
    }
}
