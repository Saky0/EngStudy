using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    public class ControleCRUDBlocos
    {
        // READ
        // Retorna a classe Interna para buscas todas os blocos Cadastrados
        public static List<classesDoDB.BlocosDto> RetornarBlocosExistentes()
        {
            try
            {
                return new ReadBlocosSS().RetornarBlocosExistentes();

            } catch(SqlException ex)
            {
                throw ex;
            }
        }



        // UPDATE
        // Retorna a classe Interna para atualizar alguma classe com os parâmetros fornecidos
        public static int AtualizarRegistroDeBlocoExistente(classesDoDB.BlocosDto bloco)
        {
            try
            {
                return new UpdateBlocosSS().atualizarRegistroDeClasse(bloco);

            } catch(SqlException ex)
            {
                throw ex;
            }
        }




        // DELETE
        // Retorna a classe Interna para excluir um bloco com os parâmetros fornecidos
        public static int ExcluirRegistroDeBlocoExistente(int id)
        {
            try
            {
                return new DeleteBlocosSS().deletarBlocoExistente(id);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }




        // CREATE
        // Retorna a classe Interna para criar um bloco com os parâmetros fornecidos
        public static int CadastrarNovoBloco(classesDoDB.BlocosDto bloco)
        {
            try
            {
                return new CreateBlocosSS().CadastrarNovoBloco(bloco);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }



        // SEARCH
        // Retorna a classe Interna para buscar algum bloco com os parâmetros fornecidos
        public static List<classesDoDB.BlocosDto> BuscarBlocoExistentePorParametros(string busca)
        {
            try
            {
                return new SearchBlocosSS().BlocosEncontradas(busca);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
