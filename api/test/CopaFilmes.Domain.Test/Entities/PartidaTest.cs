using CopaFilmes.Domain.Entities;
using Xunit;

namespace CopaFilmes.DomainTest.Entities
{
    public class PartidaTest
    {
        [Fact]
        public void DeveDefinirOVencedorCorretamente()
        {
            var filmeUm = new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8M);
            var filmeDois = new Filme("tt3501632", "Thor: Ragnarok", 2017, 7.9M);

            var partida = new Partida(filmeUm, filmeDois);

            Assert.Equal(filmeUm, partida.Vencedor);
            Assert.Equal(filmeDois, partida.Perdedor);
        }

        [Fact]
        public void DeveDefinirOVencedorCorretamenteQuandoAconteceEmpate()
        {
            var filmeUm = new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 10);
            var filmeDois = new Filme("tt3501632", "Thor: Ragnarok", 2017, 10);

            var partida = new Partida(filmeUm, filmeDois);

            Assert.Equal(filmeDois, partida.Vencedor);
            Assert.Equal(filmeUm, partida.Perdedor);
        }
    }
}