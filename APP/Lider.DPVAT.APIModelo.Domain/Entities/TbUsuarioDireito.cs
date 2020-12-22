using Lider.DPVAT.APIModelo.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Lider.DPVAT.APISimilaridade.Domain.Entities
{
    public partial class TbUsuarioDireito
    {
        public TbUsuarioDireito()
        {
        }

        public int IdUsuario { get; set; }
        public int IdDireito { get; set; }
        public int IdUsuarioAtualizacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
