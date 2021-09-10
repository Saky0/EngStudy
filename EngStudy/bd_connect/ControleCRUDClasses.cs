using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EngStudy.bd_connect
{
    public class ControleCRUDClasses
    {
        // CREATE
        // Retorna a classe Interna para cadastrar uma classe
        public static int CadastrarNovaClasse (classesDoDB.ClassesDto classeNova)
        {
            try
            {
                return new CreatClasseSS().InserirClasse(classeNova);


            } catch (SqlException ex)
            {
                throw ex;
            }
        }


        // READ
        // Retorna a classe Interna para Retornar todas as classes existentes
        public static List<classesDoDB.ClassesDto> RetornarClassesExistentes()
        {
            try
            {
                return new ReadClasseSS().RetornarClassesCadastradas();
            } catch (SqlException ex)
            {
                throw ex;
            }
        }


        // UPDATE
        // Retorna a classe Interna para Atualizar algum registro de uma CLasse Existente
        public static int AtualizarRegistroDeClasseExistente(classesDoDB.ClassesDto classe)
        {
            try
            {
                return new UpdateClasseSS().atualizarRegistroDeClasse(classe);

            } catch(SqlException ex)
            {
                throw ex;
            }
        }


        // DELETE
        // Retorna a classe Interna para Atualizar algum registro de uma CLasse Existente
        public static int ExcluirRegistroDeClasseExistente(int id)
        {
            try
            {
                return new DeleteClasseSS().deletarClasseExistente(id);

            } catch(SqlException ex)
            {
                throw ex;
            }
        }



        // SEARCH
        // Retorna a classe Interna para buscar alguma classe com os parâmetros fornecidos
        public static List<classesDoDB.ClassesDto> BuscarClasseExistentePorParametros(string busca)
        {
            try
            {
                return new SearchClasseSS().ClassesEncontradas(busca);
            } catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
