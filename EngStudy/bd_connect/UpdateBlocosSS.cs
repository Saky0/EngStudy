using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class UpdateBlocosSS
    {
        internal int atualizarRegistroDeClasse(classesDoDB.BlocosDto bloco)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "UPDATE tbBlocos SET bloco = @bloco WHERE idBloco = @id";
            cm.Parameters.Add("id", System.Data.SqlDbType.VarChar).Value = bloco.idBloco;
            cm.Parameters.Add("bloco", System.Data.SqlDbType.VarChar).Value = bloco.bloco;
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
