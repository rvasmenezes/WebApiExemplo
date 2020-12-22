using Lider.DPVAT.Administrativo.FaturamentoRCO.Helper.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Lider.DPVAT.Administrativo.FaturamentoRCO.Helper.Util.Email
{
    public class GerenciadorEmail: IGerenciadorEmail
    {
        public GerenciadorEmail()
        {
        }

        public void EnviaEmail(string body, string subject, ConfiguracaoEmailModels configuracao, List<string> Destinatarios)
        {
            var servidor = configuracao.SERVIDORSMTP;
            var emailRemente = configuracao.EMAILREMETENTE; 
            var porta = Convert.ToInt32(configuracao.PORTA);
            var senha = configuracao.SENHA;

            MailMessage email = new MailMessage();
            SmtpClient client = new SmtpClient(servidor);            
            email.From = new MailAddress(emailRemente);
            email.Subject = subject;
            email.Body = body;
            email.IsBodyHtml = true;
            foreach(var dest in Destinatarios)
                email.To.Add(new MailAddress(dest));

            client.Port = porta;
            client.Credentials = new NetworkCredential(emailRemente, senha);
            client.Send(email);            
        }

    }
}
