using System;
using System.Collections.Generic;
using System.Text;
using Lider.DPVAT.APIModelo.Application.ViewModel;
using Lider.DPVAT.APIModelo.Domain.DTO;
using Lider.DPVAT.APIModelo.Domain.Entities;
using Lider.DPVAT.APISimilaridade.Domain.Entities;

namespace Lider.DPVAT.APIModelo.Application.Interfaces
{
    public interface IUserAppService
    {
        TbUsuario ExampleMethodGet(string user_id);
        string ExampleMethodCreateUser(string user_id, string user_full_name, string user_email);
        string ExampleMethodDeleteUser(string user_id);
        string ExampleMethodUpdateUser(string user_id, string user_full_name, string user_email);
    }
}
