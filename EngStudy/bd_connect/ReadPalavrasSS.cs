using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EngStudy.bd_connect.classesDoDB;

namespace EngStudy.bd_connect
{
    class ReadPalavrasSS
    {
        internal static List<PalavrasDto> RetornarPalavrasCadastradas()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM tb_Palavras";
            cm.Connection = con;

            SqlDataReader er;


            List<PalavrasDto> palavrasEncontradas = new List<PalavrasDto>();
            con.Open();

            try
            {
                er = cm.ExecuteReader();

            } catch(SqlException ex)
            {
                con.Close();
                throw ex;
            }

            if(er.HasRows)
            {
                while (er.Read())
                {
                    PalavrasDto palavraAtual = new PalavrasDto();
                    palavraAtual.idPalavra = Convert.ToInt32(er["id_palavra"]);
                    palavraAtual.palavra = Convert.ToString(er["palavra"]);
                    palavraAtual.classe = Convert.ToInt32(er["classe"]);
                    palavraAtual.significado = Convert.ToString(er["significado"]);
                    palavraAtual.pronuncia = Convert.ToString(er["pronuncia"]);
                    palavraAtual.fraseExemplo = Convert.ToString(er["fraseExemplo"]);
                    palavraAtual.fotoExemplo = Convert.ToString(er["fotoExemplo"]);
                    palavraAtual.blocoDePalavras = Convert.ToInt32(er["blocoDePalavras"]);

                    palavrasEncontradas.Add(palavraAtual);
                }
            }

            con.Close();
            return palavrasEncontradas;
        }
    }
}
