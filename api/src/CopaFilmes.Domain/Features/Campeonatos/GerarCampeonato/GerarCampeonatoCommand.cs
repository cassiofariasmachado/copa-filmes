using System.Collections.Generic;
using CopaFilmes.Domain.Entities;
using MediatR;

namespace CopaFilmes.Domain.Features.Campeonatos.GerarCampeonato
{
    public class GerarCampeonatoCommand : IRequest<Campeonato>
    {
        public IEnumerable<string> FilmesId { get; set; }
    }
}