using System.Collections.Generic;
using LanguageExt.Common;

namespace CopaFilmes.Api.Model.Compartilhado.Responses
{
    public class ErroResponse
    {
        public string Mensagem { get; private set; }

        public IEnumerable<string> Erros { get; set; }

        public ErroResponse(string mensagem)
        {
            Mensagem = mensagem;
        }

        public ErroResponse(string mensagem, IEnumerable<string> erros)
            : this(mensagem)
        {
            Erros = erros;
        }

        public ErroResponse(Error error)
            : this(error.Message)
        {
        }
    }
}
