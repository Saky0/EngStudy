using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class CreatClasseSS
    {
        // Inseri na Tabela Classe um novo Registro de Classe
        internal int InserirClasse(classesDoDB.ClassesDto classeNova)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "INSERT INTO Classe (nome) VALUES (@classe)";
            cm.Parameters.Add("classe", System.Data.SqlDbType.VarChar).Value = classeNova.nome;
            cm.Connection = con;
            int resultado;
            con.Open();
            try
            {
                // Executa a query, se o valor for > 0, ocorreu tudo certo
                resultado = cm.ExecuteNonQuery();
                
            } catch(SqlException ex)
            {
                con.Close();
                throw ex;
            } 
            con.Close();
            return resultado;
        }
    }
}
