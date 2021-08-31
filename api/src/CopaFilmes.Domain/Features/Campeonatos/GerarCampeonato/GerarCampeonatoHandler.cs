using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.ApiServices;
using CopaFilmes.Domain.Interfaces.Services;
using LanguageExt;
using LanguageExt.Common;
using MediatR;

namespace CopaFilmes.Domain.Features.Campeonatos.GerarCampeonato
{
    public class GerarCampeonatoHandler : IRequestHandler<GerarCampeonatoCommand, Either<Error, Campeonato>>
    {
        private readonly IFilmeApiService _filmeApiService;
        private readonly ICopaService _copaService;

        public GerarCampeonatoHandler(IFilmeApiService filmeApiService, ICopaService copaService)
        {
            _filmeApiService = filmeApiService;
            _copaService = copaService;
        }

        public async Task<Either<Error, Campeonato>> Handle(GerarCampeonatoCommand request, CancellationToken cancellationToken)
        {
            var filmes = await _filmeApiService.ListarFilmesAsync(cancellationToken);

            if (filmes == default)
                return default;

            var filmesSelecionados = filmes.Where(f => request.FilmesId.Contains(f.Id)).ToList();

            return _copaService.GerarCampeonato(filmesSelecionados);
        }
    }
}
