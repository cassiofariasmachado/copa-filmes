using CopaFilmes.Domain.Entities;

namespace CopaFilmes.Api.Model.Campeonatos.Responses
{
    public class CampeonatoResponse
    {
        public Filme Campeao { get; set; }
        public Filme ViceCampeao { get; set; }


        public CampeonatoResponse(Campeonato campeonato)
        {
            Campeao = campeonato.ObterCampeao();
            ViceCampeao = campeonato.ObterViceCampeao();
        }
    }
}