using Lider.DPVAT.MODELO.ExternalService.Agent.Enums;
using Lider.DPVAT.MODELO.ExternalService.Agent.ExternalDto;
using Lider.DPVAT.MODELO.ExternalService.Agent.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Lider.DPVAT.MODELO.ExternalService.Agent
{
    public class LoginExternalAgent : ILoginExternalAgent
    {
        public IConfiguration _Configuration { get; }

        public UsuarioDTO LoginExterno(string Username, string Passwords)
        {
            var usuarioretorno = new UsuarioDTO();

            usuarioretorno = RealizaLogin(Username, Passwords);

            if (usuarioretorno == null)
            {
                usuarioretorno.CustomError = "Login Invalido";
            }
            else if (Convert.ToInt32(usuarioretorno.CodigoRetorno) == (int)EnumCodigoRetornoLoginExternal.PRIMEIRO_ACESSO)
            {
                usuarioretorno.CustomError = "Primeiro Acesso, Por favor efetue o login no sistema SisDPVAT Sinistros";
            }
            else if (Convert.ToInt32(usuarioretorno.CodigoRetorno) == (int)EnumCodigoRetornoLoginExternal.LOGIN_INVALIDO)
            {
                usuarioretorno.CustomError = "Login ou Senha Inválido";
            }
            else if ((usuarioretorno.Perfil == null) && (usuarioretorno.CodigoRetorno != null))
            {
                usuarioretorno.CustomError = "Perfil não encontrado";
            }
                return usuarioretorno;
            
        }

        public UsuarioDTO RealizaLogin(string Username, string Passwords)
        {
            using (var client = new HttpClient())
            {
                string url = _Configuration.GetSection("URL:WEBAPI")?.Value + "Username=" + Username + "&passwords=" + Passwords + "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string content = string.Empty;
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        content = @"{ ""items"" :" + sr.ReadToEnd() + "}";
                    }
                }
                ListaUsuarioDTO result = JsonConvert.DeserializeObject<ListaUsuarioDTO>(content);

                UsuarioDTO usuario = new UsuarioDTO();
                usuario.CodigoRetorno = result.items.Code;
                usuario.MensagemdeRetorno = result.items.Message;

                int i = 0;
                foreach (var item in result.items.DataArray1)
                {
                    switch (i)
                    {
                        case 0:
                            usuario.Login = item;
                            break;
                        case 1:
                            usuario.NomeCompleto = item;
                            break;
                        case 2:
                            usuario.SUSEP = item;
                            break;
                        case 3:
                            usuario.Seguradora = item;
                            break;
                        case 4:
                            usuario.Dependencia = item;
                            break;
                        case 5:
                            usuario.Digitalizada = item;
                            break;
                    }
                    i = i + 1;

                }

                foreach (var perfil in result.items.DataArray2)
                {
                    if ((perfil == "Líder - Atuarial I") || (perfil == "Líder - Atuarial II") || (perfil == "Líder - Atuarial III") || (perfil == "Líder - Atuarial IV"))
                    {
                        usuario.Perfil = perfil;
                    }
                }

                return usuario;
            }
        }
    
    }
}
