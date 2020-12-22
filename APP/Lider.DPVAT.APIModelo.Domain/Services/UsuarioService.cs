using Lider.DPVAT.APIModelo.Domain.DTO;
using Lider.DPVAT.APIModelo.Domain.Entities;
using Lider.DPVAT.APIModelo.Domain.Interfaces.Repository;
using Lider.DPVAT.APIModelo.Domain.Interfaces.Services;
using Lider.DPVAT.APISimilaridade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lider.DPVAT.APIModelo.Domain.Services
{
    public class UsuarioService : ServiceBase<TbUsuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _UsuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Dado um login, retorna a lista com todos os usuários
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public TbUsuario ExampleMethodGet(string user_id)
        {
            var user = (from u in _UsuarioRepository.GetAllAsNoTracking()
                        where u.Login == user_id
                        select u).FirstOrDefault();

            return user;
        }
        
        /// <summary>
        /// Método para realizar a criação de usuários na base
        /// </summary>
        /// <param name="user_full_name"></param>
        /// <param name="user_id"></param>
        /// <param name="user_email"></param>
        /// <param name="user_company"></param>
        /// <returns></returns>
        public string ExampleMethodCreateUser(string user_full_name, string user_id, string user_email)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(user_full_name))
            {
                sb.Append($"user_full_name: {user_full_name} Inválido ");
            }

            if (string.IsNullOrWhiteSpace(user_id))
            {
                sb.Append($"user_id: {user_id} Inválido ");
            }

            if (string.IsNullOrWhiteSpace(user_email))
            {
                sb.Append($"user_email: {user_email} Inválido ");
            }

            var usuarioJaExistente = _UsuarioRepository.GetBy(x => x.Login == user_id).Any();

            if (usuarioJaExistente)
            {
                sb.Append($"user_id: {user_id} já existe na base de dados ");
            }

            if (!string.IsNullOrWhiteSpace(sb.ToString()))
            {
                return sb.ToString();
            }

            TbUsuario novoUsuario = new TbUsuario()
            {
                IdUsuario = 0,
                Nome = user_full_name,
                Login = user_id,
                Senha = null,
                Email = user_email,
                FlagAtivo = true,
                FlagSupervisor = null,
                FlagGerente = null,
                DataAtualizacao = DateTime.Now,
                IdUsuarioAtualizacao = null,
                CrmGerente = null,
                UfCrmGerente = null,
                FlagPrimeiroLogon = true
            };

            _UsuarioRepository.Add(novoUsuario);
            _UsuarioRepository.SaveChange();

            var retorno = _UsuarioRepository.GetBy(x => x.Login == novoUsuario.Login).Any();

            if (!retorno)
                return "ERR0 - Não foi possível criar o novo usuário na base de dados";

            return string.Empty;
        }

        /// <summary>
        /// Método para excluir um usuário na base
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public string ExampleMethodDeleteUser(string user_id)
        {
            var usuario = _UsuarioRepository.GetBy(x => x.Login == user_id).FirstOrDefault();

            if (usuario == null)
            {
                return $"user_id: {user_id} inexistente";
            }

            _UsuarioRepository.Delete(usuario);
            _UsuarioRepository.SaveChange();

            var retorno = _UsuarioRepository.GetBy(x => x.Login == user_id).FirstOrDefault();

            if (retorno != null)
                return "ERR0 - Erro ao excluir o usuário da base de dados";

            return string.Empty;
        }

        /// <summary>
        /// Método para alterar dados de usuario na base
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="user_full_name"></param>
        /// <param name="user_email"></param>
        /// <returns></returns>
        public string ExampleMethodUpdateUser(string user_id, string user_full_name, string user_email)
        {
            var usuario = _UsuarioRepository.GetBy(x => x.Login == user_id).FirstOrDefault();

            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(user_id))
            {
                sb.Append($"user_id: {user_id} Inválido ");
            }
            else if (usuario == null)
            {
                sb.Append($"user_id: {user_id} não encontrado ");
            }

            if (string.IsNullOrWhiteSpace(user_full_name))
            {
                sb.Append($"user_full_name: {user_full_name} Inválido ");
            }

            if (string.IsNullOrWhiteSpace(user_email))
            {
                sb.Append($"user_email: {user_email} Inválido ");
            }

            if (!string.IsNullOrWhiteSpace(sb.ToString()))
            {
                return sb.ToString();
            }

            usuario.Nome = user_full_name;
            usuario.Email = user_email;

            _UsuarioRepository.Update(usuario);
            _UsuarioRepository.SaveChange();

            var retorno = _UsuarioRepository.GetBy(x => x.Login == user_id
                                                && x.Nome == user_full_name
                                                && x.Email == user_email).Any();

            if (!retorno)
                return "ERR0 - Não foi possível atualizar o usuário na base de dados";

            return string.Empty;
        }
    }
}
