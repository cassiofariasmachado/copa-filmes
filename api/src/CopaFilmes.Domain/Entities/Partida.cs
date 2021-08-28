namespace CopaFilmes.Domain.Entities
{
    public class Partida
    {
        public Filme FilmeUm { get; private set; }

        public Filme FilmeDois { get; private set; }

        public Filme Vencedor { get; private set; }

        public Filme Perdedor { get; private set; }

        public Partida(Filme filmeUm, Filme filmeDois)
        {
            FilmeUm = filmeUm;
            FilmeDois = filmeDois;
            Vencedor = ObterVencedor(FilmeUm, FilmeDois);
            Perdedor = ObterPerdedor(Vencedor);
        }

        private Filme ObterPerdedor(Filme vencedor)
        {
            if (vencedor == FilmeUm)
                return FilmeDois;

            return FilmeUm;
        }

        private Filme ObterVencedor(Filme filmeUm, Filme filmeDois)
        {
            if (filmeUm.Nota == filmeDois.Nota)
            {
                var desempate = string.CompareOrdinal(filmeUm.Titulo, filmeDois.Titulo);

                return desempate < 0 ? filmeUm : filmeDois;
            }

            if (filmeUm.Nota > filmeDois.Nota)
                return filmeUm;

            return filmeDois;
        }
    }
}