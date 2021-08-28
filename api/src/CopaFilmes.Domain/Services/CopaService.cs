using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services;

namespace CopaFilmes.Domain.Services
{
    public class CopaService : ICopaService
    {
        public Campeonato GerarCampeonato(IEnumerable<Filme> filmes)
        {
            var filmesOrdenados = filmes.OrderBy(c => c.Titulo).ToList();

            var campeonato = new Campeonato();

            var numeroRodada = 1;
            var maximoRodadas = ObterNumeroMaximoRodadas(filmesOrdenados.Count);

            while (numeroRodada <= maximoRodadas)
            {
                var competidores = ObterCompetidoresRodada(numeroRodada, campeonato, filmesOrdenados);

                var rodada = new Rodada(numeroRodada);

                for (int i = 0, j = competidores.Count - 1; i <= j; i++, j--)
                {
                    var filmeUm = competidores[i];
                    var filmeDois = competidores[j];

                    var partida = new Partida(filmeUm, filmeDois);

                    rodada.AdicionarPartida(partida);
                }

                campeonato.AdicionarRodada(rodada);

                numeroRodada++;
            }

            return campeonato;
        }

        private IList<Filme> ObterCompetidoresRodada(int numeroRodada, Campeonato campeonato, IList<Filme> filmes)
        {
            var ultimaRodada = campeonato.ObterRodada(numeroRodada - 1);

            if (ultimaRodada == default)
                return filmes;

            return ultimaRodada.Partidas.Select(p => p.Vencedor).ToList();
        }

        private int ObterNumeroMaximoRodadas(int competidores)
        {
            int rodadas = 0;

            for (int i = competidores; i > 1; i /= 2)
                rodadas++;

            return rodadas;
        }
    }
}