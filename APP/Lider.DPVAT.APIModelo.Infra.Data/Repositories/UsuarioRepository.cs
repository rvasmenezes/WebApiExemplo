using Lider.DPVAT.APIModelo.Domain.Entities;
using Lider.DPVAT.APIModelo.Domain.Interfaces.Repository;
using Lider.DPVAT.APIModelo.Infra.Data.Context;
using Lider.DPVAT.APIModelo.Infra.Data.UnityOfWorks;
using Lider.DPVAT.APISimilaridade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Lider.DPVAT.APIModelo.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<TbUsuario>, IUsuarioRepository
    {
        private readonly IUnitOfWork _unitOfWork;


        public UsuarioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
