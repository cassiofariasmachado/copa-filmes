using System.Threading.Tasks;
using CopaFilmes.Domain.Features.Campeonatos.GerarCampeonato;
using FluentValidation.TestHelper;
using Xunit;

namespace CopaFilmes.DomainTest.Features.Campeonatos.GerarCampeonato
{
    public class GerarCampeonatoValidatorTest
    {
        private readonly GerarCampeonatoValidator _validator;

        public GerarCampeonatoValidatorTest()
        {
            _validator = new GerarCampeonatoValidator();
        }

        [Fact]
        public async Task DevePassarPelaValidacao()
        {
            var responta = await _validator.TestValidateAsync(new GerarCampeonatoCommand
            {
                FilmesId = new[]
                {
                    "1", "2", "3", "4"
                }
            });

            responta.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task DeveRetornarErroQuandoNaoInformadoOsFilmesSelecionados()
        {
            var responta = await _validator.TestValidateAsync(new GerarCampeonatoCommand());

            responta.ShouldHaveValidationErrorFor(c => c.FilmesId);
        }
    }
}