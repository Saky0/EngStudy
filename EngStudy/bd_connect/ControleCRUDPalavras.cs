using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngStudy.bd_connect.classesDoDB;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    class ControleCRUDPalavras
    {
        // CREATE
        // Retorna a classe Interna para cadastrar uma palavra nova
        public static int InserirPalavra(PalavrasDto palavraNova)
        {
            try
            {
                return CreatPalavrasSS.InserirPalavra(palavraNova);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }



        // DELETE
        // Retorna a classe Interna para Excluir uma palavra existente
        public static int ExcluirPalavra(int id)
        {
            try
            {
                return DeletePalavrasSS.ExcluirPalavra(id);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        // UPDATE
        // Retorna a classe Interna para Atualizar uma palavra existente
        public static int AtualizarPalavra(PalavrasDto palavraNova)
        {
            try
            {
                return UpdatePalavrasSS.atualizarRegistroDePalavras(palavraNova);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        // READ
        // Retorna a classe Interna para Retorna todas as Palavras Existentes
        public static List<PalavrasDto> RetornarPalavras()
        {
            try
            {
                return ReadPalavrasSS.RetornarPalavrasCadastradas();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        // READ (PARCIAL)
        // Retorna a classe Interna para Retorna todas as Palavras Existentes, usado no upload de fotos para um READ Parcial dos dados
        public static List<PalavraParcialDto> RetornarPalavrasParcial()
        {
            try
            {
                return ReadPalavraOnlySpecsSS.RetornaQueryEspecificaPalavras();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }



        // SEARCH (POR NOME DA PALAVRA), (RETORNA VALORES PARCIAIS DAS PALAVRAS -> id_palavra, palavra e classe)
        // Retorna a classe Interna para Retorna todas as Palavras Existentes baseadas nos parâmetros passados, como o nome da palavra
        public static List<PalavraParcialDto> PesquisarPalavrasPorNome(string busca)
        {
            try
            {
                return SearchPalavrasPorNomeSS.PesquisarPalavraPorNome(busca);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        // UPDATE FOTO EM PALAVRA
        // Inseri uma foto em um registro existente de Palavra, ou seja, somente após a palavra existir
        public static int AtualizarFotoEmPalavraExistente(string caminhDaFoto, int id)
        {
            try
            {
                return UpdateFotoPalavraSS.AtualizarFotoEmPalavra(caminhDaFoto, id);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }



        // SEACRH CLASSE FOR NAME
        // Busca o id de uma classe pelo seu respectivo nome
        public static int EncontrarClassePorNome(string classe)
        {
            try
            {
                return SearchIdClasseForNameParaPalavraSS.EncontraIdClasseCorrespondente(classe);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        // SEACRH BLOCO FOR NAME
        // Busca o id de uma bloco pelo seu respectivo nome
        public static int EncontrarBlocoPorNome(string bloco)
        {
            try
            {
                return SearchIdBlocoForNameParaPalavraSS.EncontrarBlocoPorNome(bloco);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        // SEARCH BLOCO FOR ID
        // Busca um bloco pelo seu Id e retorna o nome
        public static string EncontrarBlocoPorId(int id)
        {
            try
            {
                return SearchBlocoForIdPalavraSS.EncontraBlocoPorId(id);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        // SEARCH CLASSE FOR ID
        // Busca um classe pelo seu Id e retorna o nome
        public static string EncontrarClassePorId(int id)
        {
            try
            {
                return SearchClasseForIdPalavraSS.EncontraBlocoPorId(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
