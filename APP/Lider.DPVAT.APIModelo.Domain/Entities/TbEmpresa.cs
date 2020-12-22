using Lider.DPVAT.APISimilaridade.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Lider.DPVAT.APIModelo.Domain.Entities
{
    public partial class TbEmpresa
    {
        public TbEmpresa()
        {           
        }

        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public bool FlagAtivo { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int IdUsuarioAtualizacao { get; set; }
        public int IdPerfil { get; set; }
    }
}
