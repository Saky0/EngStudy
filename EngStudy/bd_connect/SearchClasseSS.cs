using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class SearchClasseSS
    {
        internal List<classesDoDB.ClassesDto> ClassesEncontradas(string busca)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = string.Format("SELECT * FROM Classe WHERE nome LIKE '%{0}%'", busca);
            //cm.Parameters.Add("busca", System.Data.SqlDbType.VarChar).Value = busca;
            cm.Connection = con;
            SqlDataReader er;
            
            con.Open();
            try
            {
                // Executa a query
                er = cm.ExecuteReader();

            }
            catch (SqlException ex)
            {
                con.Close();
                throw ex;
            }

            // Se não gerou erros, passa os valores para a lista
            List<classesDoDB.ClassesDto> classesEncontradas = new List<classesDoDB.ClassesDto>();

            if (er.HasRows)
            {
                while (er.Read())
                {
                    classesDoDB.ClassesDto classeEncontrada = new classesDoDB.ClassesDto();

                    classeEncontrada.idClasse = Convert.ToInt32(er["id_classe"]);
                    classeEncontrada.nome = Convert.ToString(er["nome"]);

                    classesEncontradas.Add(classeEncontrada);
                }
            }

            con.Close();
            return classesEncontradas;
        }
    }
}
