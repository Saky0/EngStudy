using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngStudy.bd_connect.classesDoDB
{
    public class BlocosDto
    {
        public int idBloco { get; set; }
        public string bloco { get; set; }

        public BlocosDto(string blocoNovo)
        {
            this.bloco = blocoNovo;
        }

        public BlocosDto()
        {

        }
    }
}
