using System.Collections.Generic;

namespace CopaFilmes.Domain.Entities
{
    public class Rodada
    {
        public int Numero { get; private set; }

        public ICollection<Partida> Partidas { get; private set; }

        public Rodada(int numero)
        {
            Numero = numero;
            Partidas = new List<Partida>();
        }

        public void AdicionarPartida(Partida partida)
        {
            Partidas.Add(partida);
        }
    }
}