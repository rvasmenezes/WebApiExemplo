using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lider.DPVAT.APIModelo.Application.ViewModel;
using Lider.DPVAT.APIModelo.UI.ProviderJWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Lider.DPVAT.APIModelo.UI.Controllers
{
    /// <summary>
    /// Token controle de Acesso
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // GET: api/Token
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        /// <summary>
        /// Metodo para a solicitação do Token que é a chave para a autencitação da API.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="senha"></param>
        /// <returns>Retorna o Token para autenticar</returns>
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        public IActionResult RequestToken(string nome, string senha)
        {

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
            {
                return NotFound("Paramentros Inválidos");
            }

            if (nome != _configuration.GetSection("Usuario").Value || senha != _configuration.GetSection("Senha").Value)
            {
                return Unauthorized();
            }

            var Expiry = Convert.ToInt32(_configuration.GetSection("Expiry").Value);

            var token = new TokenJWTBuilder()
             .AddSecurityKey(JwtSecurityKey.Create(_configuration.GetSection("SecurityKey").Value))
             .AddSubject(_configuration.GetSection("Subject").Value)
             .AddIssuer(_configuration.GetSection("Issuer").Value)
             .AddAudience(_configuration.GetSection("Audience").Value)
             .AddClaim(_configuration.GetSection("Claim").Value, _configuration.GetSection("ClaimNumber").Value)
             .AddExpiry(Expiry)
             .Builder();

            return Ok(new
            {
                token = token.value
            });
        }

    }
}
