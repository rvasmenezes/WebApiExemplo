using System;

namespace Lider.DPVAT.APIModelo.Domain.DTO
{
    public partial class DireitoDTO
    {
        public int IdDireito { get; set; }
        public string Descricao { get; set; }
        public int IdUsuarioAtualizacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
