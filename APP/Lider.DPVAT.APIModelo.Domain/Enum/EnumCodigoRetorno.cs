using System;
using System.Collections.Generic;
using System.Text;

namespace Lider.DPVAT.APIModelo.Domain
{
   public enum EnumCodigoRetorno
    {
        Sucesso = 00,
        ErroParametro = 01,
        Naoforamencontradoresultadoparasuapesquisa = 02,
        Exception = 03        
    }
}
