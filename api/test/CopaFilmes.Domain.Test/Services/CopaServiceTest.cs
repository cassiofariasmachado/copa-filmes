using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Domain.Services;
using Xunit;

namespace CopaFilmes.DomainTest.Services
{
    public class CopaServiceTest
    {
        private readonly ICopaService _copaService;

        public CopaServiceTest()
        {
            _copaService = new CopaService();
        }

        [Fact]
        public void DeveGerarCampeonatoCorretamente()
        {
            var vingadores = new Filme("1", "Vingadores: Guerra Infinita", 2018, 8.8M);
            var osIncriveis = new Filme("2", "Os Incríveis", 2004, 8.0M);

            var filmes = new List<Filme>
            {
                vingadores,
                new("3", "Thor: Ragnarok", 2017, 7.9M),
                osIncriveis,
                new("4", "Jurassic World: Reino Ameaçado", 2018, 6.7M)
            };

            var campeonato = _copaService.GerarCampeonato(filmes);

            var campeao = campeonato.ObterCampeao();
            var viceCampeao = campeonato.ObterViceCampeao();

            Assert.Equal(vingadores, campeao);
            Assert.Equal(osIncriveis, viceCampeao);
        }
    }
}