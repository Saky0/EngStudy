using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngStudy.bd_connect
{
    class CreateBlocosSS
    {
        // Função que recebe uma instancia de Bloco para criar um novo registro na tbBlocos
        internal int CadastrarNovoBloco(classesDoDB.BlocosDto blocoNovo)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "INSERT INTO tbBlocos(bloco) VALUES(@bloco)";
            cm.Parameters.Add("bloco", System.Data.SqlDbType.VarChar).Value = blocoNovo.bloco;
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
                throw ex;
            }
            finally
            {
                con.Close();
            }
            
            return resultado;
        }
    }
}
