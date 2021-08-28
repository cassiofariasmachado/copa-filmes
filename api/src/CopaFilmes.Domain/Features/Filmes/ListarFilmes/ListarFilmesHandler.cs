using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.ApiServices;
using MediatR;

namespace CopaFilmes.Domain.Features.Filmes.ListarFilmes
{
    public class ListarFilmesHandler : IRequestHandler<ListarFilmesCommand, IEnumerable<Filme>>
    {
        private readonly IFilmeApiService _filmeApiService;

        public ListarFilmesHandler(IFilmeApiService filmeApiService)
        {
            _filmeApiService = filmeApiService;
        }

        public Task<IEnumerable<Filme>> Handle(ListarFilmesCommand request, CancellationToken cancellationToken)
            => _filmeApiService.ListarFilmesAsync(cancellationToken);
    }
}