using System.Collections.Generic;
using CopaFilmes.Domain.Entities;
using LanguageExt;
using LanguageExt.Common;
using MediatR;

namespace CopaFilmes.Domain.Features.Campeonatos.GerarCampeonato
{
    public class GerarCampeonatoCommand : IRequest<Either<Error, Campeonato>>
    {
        public IEnumerable<string> FilmesId { get; set; }
    }
}
