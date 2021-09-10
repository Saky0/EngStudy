namespace EngStudy.bd_connect.classesDoDB
{
    public class FrasesDto
    {
        public int idFrase { get; set; }
        public string frase { get; set; }
        public string traducao { get; set; }
        public int dificuldade { get; set; }
        public int idPalavraFK { get; set; }
        public string palavraChaveFK { get; set; }
        public string categoria { get; set; }

    }
}
