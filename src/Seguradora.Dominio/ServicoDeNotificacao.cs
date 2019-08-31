using Seguradora.Dominio.Services;
using System.Collections.Generic;

namespace Seguradora.Dominio
{
    public class ServicoDeNotificacao : IServicoDeNotificacao
    {
        public ServicoDeNotificacao()
        {
            notificacoes = new List<Notificacao>();
        }

        private List<Notificacao> notificacoes;

        public IEnumerable<Notificacao> Notificacoes
        {
            get
            {
                return notificacoes;
            }
        }

        public void PostarNotificacao(string notificacao)
        {
            notificacoes.Add(new Notificacao { Mensagem = notificacao });    
        }
    }
}
