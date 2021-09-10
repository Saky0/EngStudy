using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class SearchBlocosSS
    {
        internal List<classesDoDB.BlocosDto> BlocosEncontradas(string busca)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = string.Format("SELECT * FROM tbBlocos WHERE bloco LIKE '%{0}%'", busca);
            cm.Connection = con;
            SqlDataReader er;

            con.Open();
            List<classesDoDB.BlocosDto> blocosEncontrados = new List<classesDoDB.BlocosDto>();

            try
            {
                // Executa a query, se o valor for > 0, ocorreu tudo certo

                er = cm.ExecuteReader();

            }
            catch (SqlException ex)
            {
                con.Close();
                throw ex;
            }
           
            if (er.HasRows)
            {
                while (er.Read())
                {
                    classesDoDB.BlocosDto bloco = new classesDoDB.BlocosDto();
                    bloco.idBloco = Convert.ToInt32(er["idBloco"]);
                    bloco.bloco = Convert.ToString(er["bloco"]);

                    blocosEncontrados.Add(bloco);
                }
            }
            con.Close();
            return blocosEncontrados;
        }
    }
    
}
