using System.Collections.Generic;
using CopaFilmes.Domain.Entities;

namespace CopaFilmes.Domain.Interfaces.Services
{
    public interface ICopaService
    {
        Campeonato GerarCampeonato(IEnumerable<Filme> filmes);
    }
}