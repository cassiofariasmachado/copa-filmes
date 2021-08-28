using FluentValidation;

namespace CopaFilmes.Domain.Features.Campeonatos.GerarCampeonato
{
    public class GerarCampeonatoValidator : AbstractValidator<GerarCampeonatoCommand>
    {
        public GerarCampeonatoValidator()
        {
            RuleFor(g => g.FilmesId)
                .NotEmpty()
                .WithMessage("Obrigatório informar os filmes selecionados para a copa.");
        }
    }
}