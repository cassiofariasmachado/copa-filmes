using System.Collections.Generic;
using CopaFilmes.Domain.Entities;
using MediatR;

namespace CopaFilmes.Domain.Features.Filmes.ListarFilmes
{
    public class ListarFilmesCommand : IRequest<IEnumerable<Filme>>
    {
    }
}