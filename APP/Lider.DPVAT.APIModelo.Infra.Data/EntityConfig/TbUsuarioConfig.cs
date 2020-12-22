using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lider.DPVAT.APISimilaridade.Domain.Entities;

namespace PSLAdministrativa.Data.EntityConfig
{
    public class TbUsuarioConfig : IEntityTypeConfiguration<TbUsuario>
    {
        public void Configure(EntityTypeBuilder<TbUsuario> entity)
        {
            entity.HasKey(e => e.IdUsuario)
                    .ForSqlServerIsClustered(false);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("IdUsuario");
            entity.Property(e => e.Nome).HasColumnName("Nome");
            entity.Property(e => e.Login).HasColumnName("Login");
            entity.Property(e => e.Senha).HasColumnName("Senha");
            entity.Property(e => e.Email).HasColumnName("Email");
            entity.Property(e => e.FlagAtivo).HasColumnName("FlagAtivo");
            entity.Property(e => e.FlagSupervisor).HasColumnName("FlagSupervisor");
            entity.Property(e => e.FlagGerente).HasColumnName("FlagGerente");
            entity.Property(e => e.DataAtualizacao).HasColumnName("DataAtualizacao");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("IdUsuarioAtualizacao");
            entity.Property(e => e.CrmGerente).HasColumnName("CrmGerente");
            entity.Property(e => e.UfCrmGerente).HasColumnName("UfCrmGerente");
            entity.Property(e => e.FlagPrimeiroLogon).HasColumnName("FlagPrimeiroLogon");
        }
    }
}
