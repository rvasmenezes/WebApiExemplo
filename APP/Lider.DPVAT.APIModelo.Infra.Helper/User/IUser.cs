using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Lider.DPVAT.MODELO.Help.User
{
    public interface IUser
    {
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
        string NomeCompleto { get; }
        string login { get; }
        int IdUsuario { get; }
        string IdAcesso { get; }
        string Perfil { get; }
        string Seguradora { get; }

    }
}
