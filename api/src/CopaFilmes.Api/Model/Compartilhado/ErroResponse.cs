namespace CopaFilmes.Api.Model.Compartilhado
{
    public class ErroResponse
    {
        public string Mensagem { get; private set; }

        public ErroResponse(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}