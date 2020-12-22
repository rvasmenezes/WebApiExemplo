using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lider.DPVAT.APISimilaridade.Domain.Entities;

namespace PSLAdministrativa.Data.EntityConfig
{
    public class TbUsuarioDireitoConfig : IEntityTypeConfiguration<TbUsuarioDireito>
    {
        public void Configure(EntityTypeBuilder<TbUsuarioDireito> entity)
        {
            entity.HasKey(e => e.IdUsuario)
                    .ForSqlServerIsClustered(false);

            entity.ToTable("UsuarioDireito");

            entity.Property(e => e.IdUsuario).HasColumnName("IdUsuario");
            entity.Property(e => e.IdDireito).HasColumnName("IdDireito");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("IdUsuarioAtualizacao");
            entity.Property(e => e.DataAtualizacao).HasColumnName("DataAtualizacao");
        }
    }
}
