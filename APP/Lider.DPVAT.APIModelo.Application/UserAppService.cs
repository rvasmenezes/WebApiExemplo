using Lider.DPVAT.APIModelo.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Lider.DPVAT.APIModelo.Domain.Entities;
using Lider.DPVAT.APIModelo.Domain.Interfaces;
using Lider.DPVAT.APIModelo.Domain.Interfaces.Services;
using System.Linq;
using Lider.DPVAT.APIModelo.Domain.DTO;
using Lider.DPVAT.APIModelo.Application.ViewModel;
using AutoMapper;
using Lider.DPVAT.APISimilaridade.Domain.Entities;

namespace Lider.DPVAT.APIModelo.Application
{
    public class UserAppService : IUserAppService
    {

        private readonly IUsuarioService _UsuarioService;
        private readonly IMapper _Mapper;

        public UserAppService(IUsuarioService usuarioService,
                                      IMapper mapper)
        {
            _UsuarioService = usuarioService;
            _Mapper = mapper;
        }

        /// <summary>
        /// Dado um login, retorna a lista com todos os usuários
        /// </summary>
        /// <param name="NuSinistro"></param>
        /// <returns>Retorna a lista de PessoaCrmDTO</returns>
        public TbUsuario ExampleMethodGet(string user_id)
        {
            return _UsuarioService.ExampleMethodGet(user_id);
        }

        /// <summary>
        /// Método para realizar a criação de usuários na base
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="user_full_name"></param>
        /// <param name="user_email"></param>
        /// <param name="user_company"></param>
        /// <returns></returns>
        public string ExampleMethodCreateUser(string user_id,
                                             string user_full_name,
                                             string user_email)
        {
            return _UsuarioService.ExampleMethodCreateUser(user_full_name, user_id, user_email);
        }

        /// <summary>
        /// Método para excluir um usuário na base
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public string ExampleMethodDeleteUser(string user_id)
        {
            return _UsuarioService.ExampleMethodDeleteUser(user_id);
        }

        /// <summary>
        /// Método para alterar dados de usuario na base
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="user_full_name"></param>
        /// <param name="user_email"></param>
        /// <param name="user_company"></param>
        /// <returns></returns>
        public string ExampleMethodUpdateUser(string user_id, string user_full_name, string user_email)
        {
            return _UsuarioService.ExampleMethodUpdateUser(user_id,
                                                             user_full_name,
                                                             user_email);
        }
    }
}
