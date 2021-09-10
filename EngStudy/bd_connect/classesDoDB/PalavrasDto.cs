namespace EngStudy.bd_connect.classesDoDB
{
    public class PalavrasDto
    {
        /*
        private int id_palavra;
        public int Id_palavra
        {
            get { return id_palavra; }
            set { id_palavra = value; }
        }


        Maneira mais explicita, adicionar mais lógica
        */
        public int idPalavra { get; set; }
        public string palavra { get; set; }
        public string significado { get; set; }
        public string pronuncia { get; set; }
        public int classe { get; set; }
        public string fraseExemplo { get; set; }
        public string fotoExemplo { get; set; }
        public int blocoDePalavras { get; set; }



    }
}
