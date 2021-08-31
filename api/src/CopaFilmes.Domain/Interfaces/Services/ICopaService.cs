using System.Collections.Generic;
using CopaFilmes.Domain.Entities;
using LanguageExt;
using LanguageExt.Common;

namespace CopaFilmes.Domain.Interfaces.Services
{
    public interface ICopaService
    {
        Either<Error, Campeonato> GerarCampeonato(IEnumerable<Filme> filmes);
    }
}
