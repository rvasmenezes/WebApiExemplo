using Lider.DPVAT.APIModelo.Domain.DTO;
using Lider.DPVAT.APIModelo.Domain.Entities;
using Lider.DPVAT.APISimilaridade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lider.DPVAT.APIModelo.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<TbUsuario>
    {
        TbUsuario ExampleMethodGet(string user_id);
        string ExampleMethodCreateUser(string user_full_name, string user_id, string user_email);
        string ExampleMethodDeleteUser(string user_id);
        string ExampleMethodUpdateUser(string user_id, string user_full_name, string user_email);
    }
}
