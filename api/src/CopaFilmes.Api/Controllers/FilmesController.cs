using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Features.Filmes.ListarFilmes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilmesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lista os filmes disponíveis.
        /// </summary>
        [HttpGet]
        public Task<IEnumerable<Filme>> ObterFilmes(CancellationToken cancellationToken)
            => _mediator.Send(new ListarFilmesCommand(), cancellationToken);
    }
}