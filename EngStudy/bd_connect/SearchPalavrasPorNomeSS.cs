using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EngStudy.bd_connect.classesDoDB;

namespace EngStudy.bd_connect
{
    class SearchPalavrasPorNomeSS
    {
        internal static List<PalavraParcialDto> PesquisarPalavraPorNome(string busca)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = String.Format("SELECT id_palavra, palavra, classe FROM tb_Palavras WHERE palavra LIKE '%{0}%'", busca);
            cm.Connection = con;

            SqlDataReader er;


            List<PalavraParcialDto> palavrasEncontradas = new List<PalavraParcialDto>();
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

            if (er.HasRows)
            {
                while (er.Read())
                {
                    PalavraParcialDto palavraAtual = new PalavraParcialDto();
                    palavraAtual.idPalavra = Convert.ToInt32(er["id_palavra"]);
                    palavraAtual.palavra = Convert.ToString(er["palavra"]);
                    palavraAtual.classe = Convert.ToString(er["classe"]);
                    

                    palavrasEncontradas.Add(palavraAtual);
                }
            }

            con.Close();
            return palavrasEncontradas;
        }
    }
}
