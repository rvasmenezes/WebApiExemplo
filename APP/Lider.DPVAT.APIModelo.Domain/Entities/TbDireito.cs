using Lider.DPVAT.APISimilaridade.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Lider.DPVAT.APIModelo.Domain.Entities
{
    public partial class TbDireito
    {
        public TbDireito()
        {           
        }

        public int IdDireito { get; set; }
        public string Descricao { get; set; }
        public int IdUsuarioAtualizacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
