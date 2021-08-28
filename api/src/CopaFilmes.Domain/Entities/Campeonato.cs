using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain.Entities
{
    public class Campeonato
    {
        private readonly IDictionary<int, Rodada> _rodadas;

        public Campeonato()
        {
            _rodadas = new SortedDictionary<int, Rodada>();
        }

        private Rodada ObterUltimaRodada()
            => _rodadas.LastOrDefault().Value;

        private Partida ObterFinal()
            => ObterUltimaRodada()?.Partidas?.LastOrDefault();

        public Filme ObterCampeao()
            => ObterFinal()?.Vencedor;

        public Filme ObterViceCampeao()
            => ObterFinal()?.Perdedor;

        public Rodada ObterRodada(int numeroRodada)
        {
            if (!_rodadas.TryGetValue(numeroRodada, out var rodada))
                return default;

            return rodada;
        }

        public void AdicionarRodada(Rodada rodada)
            => _rodadas.Add(rodada.Numero, rodada);
    }
}