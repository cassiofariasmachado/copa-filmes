using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Features.Filmes.ListarFilmes;
using CopaFilmes.Domain.Interfaces.ApiServices;
using FakeItEasy;
using Xunit;

namespace CopaFilmes.DomainTest.Features.Filmes.ListarFilmes
{
    public class ListarFilmesHandlerTest
    {
        private readonly ListarFilmesHandler _handler;

        private readonly IFilmeApiService _filmeApiService;

        public ListarFilmesHandlerTest()
        {
            _filmeApiService = A.Fake<IFilmeApiService>();

            _handler = new ListarFilmesHandler(_filmeApiService);
        }

        [Fact]
        public async Task DeveRetornarOsFilmesCorretamente()
        {
            var filmes = new List<Filme>
            {
                new("1", "Thor: Ragnarok", 2017, 7.9M),
                new("2", "Jurassic World: Reino Ameaçado", 2018, 6.7M)
            };

            A.CallTo(() => _filmeApiService.ListarFilmesAsync(A<CancellationToken>.Ignored))
                .Returns(filmes);

            var retorno = await _handler.Handle(new ListarFilmesCommand(), default);

            Assert.Equal(filmes, retorno);
            Assert.Equal(filmes.Count, retorno.Count());
        }

    }
}