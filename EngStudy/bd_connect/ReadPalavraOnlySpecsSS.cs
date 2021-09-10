using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EngStudy.bd_connect.classesDoDB;

namespace EngStudy.bd_connect
{
    class ReadPalavraOnlySpecsSS
    {
        // Retorna um Query especifica das palavras cadastradas em tbPalavras
        internal static List<PalavraParcialDto> RetornaQueryEspecificaPalavras()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            SqlCommand cm = new SqlCommand();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT id_palavra, palavra, classe FROM tb_Palavras";
            cm.Connection = con;

            SqlDataReader er;
            con.Open();

            // Tentar realizar a conexão e retornar os dados registrados
            try
            {
                er = cm.ExecuteReader();
            } catch(SqlException ex)
            {
                con.Close();
                throw ex;
            }

            List<PalavraParcialDto> palavrasEncontradas = new List<PalavraParcialDto>();

            if(er.HasRows)
            {
                while (er.Read())
                {
                    PalavraParcialDto palavraAtual = new PalavraParcialDto();

                    palavraAtual.palavra = Convert.ToString(er["palavra"]);
                    palavraAtual.idPalavra = Convert.ToInt32(er["id_palavra"]);
                    palavraAtual.classe = Convert.ToString(er["classe"]);

                    palavrasEncontradas.Add(palavraAtual);
                }
            }

            con.Close();
            return palavrasEncontradas;
                    

        }
    }
}
