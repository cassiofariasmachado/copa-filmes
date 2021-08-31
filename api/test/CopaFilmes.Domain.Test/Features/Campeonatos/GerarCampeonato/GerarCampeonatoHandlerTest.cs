using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Features.Campeonatos.GerarCampeonato;
using CopaFilmes.Domain.Interfaces.ApiServices;
using CopaFilmes.Domain.Interfaces.Services;
using FakeItEasy;
using Xunit;

namespace CopaFilmes.DomainTest.Features.Campeonatos.GerarCampeonato
{
    public class GerarCampeonatoHandlerTest
    {
        private readonly GerarCampeonatoHandler _handler;

        private readonly IFilmeApiService _filmeApiService;
        private readonly ICopaService _copaService;

        public GerarCampeonatoHandlerTest()
        {
            _filmeApiService = A.Fake<IFilmeApiService>();
            _copaService = A.Fake<ICopaService>();

            _handler = new GerarCampeonatoHandler(_filmeApiService, _copaService);
        }

        [Fact]
        public async Task DeveRetornarOCampeonatoCorretamente()
        {
            var filmes = new List<Filme>
            {
                new("1", "Vingadores: Guerra Infinita", 2018, 8.8M),
                new("2", "Thor: Ragnarok", 2017, 7.9M),
                new("3", "Os Incríveis", 2004, 8.0M),
                new("4", "Jurassic World: Reino Ameaçado", 2018, 6.7M)
            };

            var campeonato = new Campeonato();

            A.CallTo(() => _filmeApiService.ListarFilmesAsync(A<CancellationToken>.Ignored))
                .Returns(filmes);

            A.CallTo(() => _copaService.GerarCampeonato(A<IEnumerable<Filme>>.Ignored))
                .Returns(campeonato);

            var request = new GerarCampeonatoCommand
            {
                FilmesId = filmes.Select(f => f.Id)
            };

            var retorno = await _handler.Handle(request, default);

            A.CallTo(() => _copaService.GerarCampeonato(A<IEnumerable<Filme>>.Ignored))
                .MustHaveHappened();

            Assert.Equal(campeonato, retorno);
        }
    }
}