using System;
using System.Collections.Generic;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Domain.Services;
using LanguageExt;
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
            var osIncriveis2 = new Filme("1", "Os Incríveis 2", 2004, 8.0M);
            var vingadores = new Filme("5", "Vingadores: Guerra Infinita", 2018, 8.8M);

            var filmes = new List<Filme>
            {
                osIncriveis2,
                new("2", "Jurassic World: Reino Ameaçado", 2018, 6.7M),
                new("3", "Oito Mulheres e um Segredo", 2018, 6.3M),
                new("4", "Hereditário", 2018, 7.8M),
                vingadores,
                new("6", "Deadpool 2", 2018, 8.1M),
                new("7", "Han Solo: Uma História Star Wars", 2018, 7.2M),
                new("8", "Thor: Ragnarok", 2017, 7.9M),
            };

            var resultado = _copaService.GerarCampeonato(filmes);

            resultado.Match(campeonato =>
                {
                    var campeao = campeonato.ObterCampeao();
                    var viceCampeao = campeonato.ObterViceCampeao();

                    Assert.Equal(vingadores, campeao);
                    Assert.Equal(osIncriveis2, viceCampeao);
                },
                error => Assert.True(error.IsNull())
            );
        }

        private static IEnumerable<Filme> DoisFilmes => new Filme[]
        {
            new("1", "Os Incríveis 2", 2004, 8.0M), new("2", "Jurassic World: Reino Ameaçado", 2018, 6.7M)
        };

        public static IEnumerable<object[]> FilmesInvalidos()
        {
            yield return new object[]
            {
                Array.Empty<Filme>()
            };

            yield return new object[]
            {
                DoisFilmes
            };
        }

        [Theory]
        [MemberData(nameof(FilmesInvalidos))]
        public void DeveRetornarErroSeInformadoUmaQuantidadeInvalidaDeFilmes(IEnumerable<Filme> filmes)
        {
            var resultado = _copaService.GerarCampeonato(filmes);

            resultado.Match(
                campeonato => Assert.True(campeonato.IsNull()),
                error =>
                {
                    Assert.False(error.IsNull());
                    Assert.Equal("É necessário 8 filmes para gerar o campeonato", error.Message);
                }
            );
        }
    }
}
