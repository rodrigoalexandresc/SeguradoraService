using System.Collections.Generic;

namespace Seguradora.Dominio.Services
{
    public interface IServicoDeNotificacao
    {
        IEnumerable<Notificacao> Notificacoes { get; }

        void PostarNotificacao(string notificacao);
    }
}
