using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngStudy.exceptions;

namespace EngStudy.classes
{
    public class VerificarFotoExistente
    {
        public static bool VerificarFoto(string caminhoFoto)
        {
            if (File.Exists(caminhoFoto))
            {
                return true;

            } else
            {
                throw new fotoNaoEncontradaExceptioncs();
            }

            
        }
    }
}
