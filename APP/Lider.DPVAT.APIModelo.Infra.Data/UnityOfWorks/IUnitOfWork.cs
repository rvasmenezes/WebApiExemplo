using Lider.DPVAT.APIModelo.Domain.Entities;
using Lider.DPVAT.APIModelo.Domain.Interfaces.Repository;
using Lider.DPVAT.APIModelo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lider.DPVAT.APIModelo.Infra.Data.UnityOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        ExampleAPIProjectContext Context { get; }
        void Commit();
    }
}
