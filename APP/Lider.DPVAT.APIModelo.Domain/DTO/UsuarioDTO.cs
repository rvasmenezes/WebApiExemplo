using System;

namespace Lider.DPVAT.APIModelo.Domain.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool FlagAtivo { get; set; }
        public bool? FlagSupervisor { get; set; }
        public bool? FlagGerente { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int? IdUsuarioAtualizacao { get; set; }
        public string CrmGerente { get; set; }
        public string UfCrmGerente { get; set; }
        public bool FlagPrimeiroLogon { get; set; }
    }
}
