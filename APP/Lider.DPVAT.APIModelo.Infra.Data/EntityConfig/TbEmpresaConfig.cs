using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lider.DPVAT.APIModelo.Domain.Entities;

namespace PSLAdministrativa.Data.EntityConfig
{
    public class TbEmpresaConfig : IEntityTypeConfiguration<TbEmpresa>
    {
        public void Configure(EntityTypeBuilder<TbEmpresa> entity)
        {
            entity.HasKey(e => e.IdEmpresa)
                    .ForSqlServerIsClustered(false);

            entity.ToTable("Empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("IdEmpresa");
            entity.Property(e => e.Nome).HasColumnName("Nome");
            entity.Property(e => e.FlagAtivo).HasColumnName("FlagAtivo");
            entity.Property(e => e.DataAtualizacao).HasColumnName("DataAtualizacao");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("IdUsuarioAtualizacao");
            entity.Property(e => e.IdPerfil).HasColumnName("IdPerfil");
        }
    }
}
