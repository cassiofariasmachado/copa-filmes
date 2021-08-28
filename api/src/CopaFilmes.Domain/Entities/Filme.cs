namespace CopaFilmes.Domain.Entities
{
    public class Filme
    {
        public string Id { get; private set; }
        public string Titulo { get; private set; }
        public int Ano { get; private set; }
        public decimal Nota { get; private set; }

        public Filme(string id, string titulo, int ano, decimal nota)
        {
            Id = id;
            Titulo = titulo;
            Ano = ano;
            Nota = nota;
        }
    }
}