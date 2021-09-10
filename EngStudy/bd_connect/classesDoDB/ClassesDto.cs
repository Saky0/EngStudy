namespace EngStudy.bd_connect.classesDoDB
{
    public class ClassesDto
    {
        public int idClasse { get; set; }
        public string nome { get; set; }

        public ClassesDto(string nome)
        {
            this.nome = nome;
        }

        
        public ClassesDto()
        {

        }

    }
}
