using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CopaFilmes.Api.Model.Campeonatos.Responses;
using CopaFilmes.Api.Model.Compartilhado.Responses;
using CopaFilmes.Domain.Features.Campeonatos.GerarCampeonato;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampeonatosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CampeonatosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gera uma copa com os filmes informados.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ErroResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CampeonatoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GerarCampeonato([FromBody] GerarCampeonatoCommand request, CancellationToken cancellationToken)
        {
            var resposta = await _mediator.Send(request, cancellationToken);

            return resposta.Match<IActionResult>(
                campeonato => Ok(new CampeonatoResponse(campeonato)),
                erro => BadRequest(new ErroResponse(erro))
            );
        }
    }
}
