using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Lider.DPVAT.MODELO.Help.User
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string NomeCompleto => _accessor.HttpContext.User.Identity.Name;
        public string login => GetClaimsIdentity().FirstOrDefault(a => a.Type == "User")?.Value;
        public int IdUsuario => Convert.ToInt32(GetClaimsIdentity().FirstOrDefault(a => a.Type == "IdUser")?.Value);
        public string IdAcesso => GetClaimsIdentity().FirstOrDefault(a => a.Type == "IdAcesso")?.Value;
        public string Seguradora => GetClaimsIdentity().FirstOrDefault(a => a.Type == "Seguradora")?.Value;
        public string Perfil => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Role)?.Value;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;

        }
        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
