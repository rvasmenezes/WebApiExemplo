using Lider.DPVAT.Administrativo.FaturamentoRCO.Helper.Models;
using System.Collections.Generic;

namespace Lider.DPVAT.Administrativo.FaturamentoRCO.Helper.Util.Email
{
    public interface IGerenciadorEmail
    {
        void EnviaEmail(string body, string subject, ConfiguracaoEmailModels configuracao, List<string> destinatarios);
    }
}
