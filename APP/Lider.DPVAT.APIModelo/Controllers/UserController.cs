using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Lider.DPVAT.APIModelo.Application.Interfaces;
using Lider.DPVAT.APIModelo.Application.ViewModel;
using Lider.DPVAT.APIModelo.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lider.DPVAT.APIModelo.UI.Controllers
{
    /// <summary>
    /// Api de Ponteiramento de Sinistro.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _UserAppService;

        public UserController(IUserAppService userAppService)
        {
            _UserAppService = userAppService;
        }

        /// <summary>
        /// Método para Verificar a existência de um usuário na base.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult VerificarExistenciaDeUsuario([FromBody] UsuarioViewModel request)
        {
            var user = _UserAppService.ExampleMethodGet(request.user_id);

            bool retorno = user != null;

            return Ok(new
            {
                return_code = ((int)HttpStatusCode.OK).ToString(),
                return_msg = "",
                user_exists = retorno ? "1" : "0"
            });
        }

        /// <summary>
        /// Método para realizar a criação de um usuário na base.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CriacaoDeUsuario([FromBody] UsuarioViewModel request)
        {
            var retorno = _UserAppService.ExampleMethodCreateUser(request.user_id, request.user_full_name, request.user_email);

            return Ok(new
            {
                return_code = ((int)HttpStatusCode.OK).ToString(),
                return_msg = retorno,
                user_created = string.IsNullOrWhiteSpace(retorno) ? "1" : "0"
            });
        }

        /// <summary>
        /// Método para realizar a exclusão de um usuário na base.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ExclusaoDeUsuario([FromBody] UsuarioViewModel request)
        {
            var retorno = _UserAppService.ExampleMethodDeleteUser(request.user_id);

            return Ok(new
            {
                return_code = ((int)HttpStatusCode.OK).ToString(),
                return_msg = retorno,
                user_removed = string.IsNullOrWhiteSpace(retorno) ? "1" : "0"
            });
        }

        /// <summary>
        /// Método para atualizar dados do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AtualizarDadosUsuario([FromBody] UsuarioViewModel request)
        {
            var retorno = _UserAppService.ExampleMethodUpdateUser(request.user_id,
                                                                    request.user_full_name,
                                                                    request.user_email);
            return Ok(new
            {
                return_code = ((int)HttpStatusCode.OK).ToString(),
                return_msg = retorno,
                user_updated = string.IsNullOrWhiteSpace(retorno) ? "1" : "0"
            });
        }
    }
}
