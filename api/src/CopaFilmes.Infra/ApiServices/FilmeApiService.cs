using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.ApiServices;

namespace CopaFilmes.Infra.ApiServices
{
    public class FilmeApiService : IFilmeApiService
    {
        private readonly HttpClient _httpClient;

        public FilmeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Filme>> ListarFilmesAsync(CancellationToken cancellationToken)
            => _httpClient.GetFromJsonAsync<IEnumerable<Filme>>("api/filmes", cancellationToken);
    }
}