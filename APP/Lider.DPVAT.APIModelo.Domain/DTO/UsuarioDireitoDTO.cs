using System;

namespace Lider.DPVAT.APIModelo.Domain.DTO
{
    public partial class UsuarioDireitoDTO
    {
        public int IdUsuario { get; set; }
        public int IdDireito { get; set; }
        public int IdUsuarioAtualizacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
