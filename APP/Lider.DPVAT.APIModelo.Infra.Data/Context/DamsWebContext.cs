using Microsoft.EntityFrameworkCore;
using PSLAdministrativa.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;
using Lider.DPVAT.APIModelo.Domain.Entities;
using Lider.DPVAT.APISimilaridade.Domain.Entities;

namespace Lider.DPVAT.APIModelo.Infra.Data.Context
{
    public class ExampleAPIProjectContext : DbContext
    {
        public ExampleAPIProjectContext(DbContextOptions<ExampleAPIProjectContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(150000);
        }

        #region DbSets

        public virtual DbSet<TbDireito> TbDireito { get; set; }
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }
        public virtual DbSet<TbUsuarioDireito> TbUsuarioDireito { get; set; }
        public virtual DbSet<TbEmpresa> TbEmpresa { get; set; }

        #endregion

        #region Configurações
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configurações Externas            

            modelBuilder.ApplyConfiguration(new TbDireitoConfig());
            modelBuilder.ApplyConfiguration(new TbEmpresaConfig());
            modelBuilder.ApplyConfiguration(new TbUsuarioConfig());
            modelBuilder.ApplyConfiguration(new TbUsuarioDireitoConfig());

            #endregion

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
