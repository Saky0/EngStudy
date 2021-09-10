using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class ReadClasseSS
    {
        internal List<classesDoDB.ClassesDto> RetornarClassesCadastradas()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Classe"; // Query para retornar todos valores da table Classes
            cm.Connection = con;

            SqlDataReader er;
            con.Open();
            try
            {
                
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

                    classeEncontrada.idClasse = Convert.ToInt32(er["idClasse"]);
                    classeEncontrada.nome = Convert.ToString(er["nome"]);

                    classesEncontradas.Add(classeEncontrada);
                }
            }

            // Retorna Tudo que encontrou
            con.Close();
            return classesEncontradas;
        }
    }
}
