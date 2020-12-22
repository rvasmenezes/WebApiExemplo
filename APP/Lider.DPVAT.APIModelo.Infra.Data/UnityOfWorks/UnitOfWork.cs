using Lider.DPVAT.APIModelo.Domain.Entities;
using Lider.DPVAT.APIModelo.Domain.Interfaces;
using Lider.DPVAT.APIModelo.Domain.Interfaces.Repository;
using Lider.DPVAT.APIModelo.Infra.Data.Context;
using Lider.DPVAT.APIModelo.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lider.DPVAT.APIModelo.Infra.Data.UnityOfWorks
{
        public class UnitOfWork : IUnitOfWork
        {
        public ExampleAPIProjectContext Context { get; }

        public UnitOfWork(ExampleAPIProjectContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
