using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;

namespace CopaFilmes.Domain.Interfaces.ApiServices
{
    public interface IFilmeApiService
    {
        Task<IEnumerable<Filme>> ListarFilmesAsync(CancellationToken cancellationToken);
    }
}