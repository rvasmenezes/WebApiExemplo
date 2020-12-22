using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lider.DPVAT.APIModelo.Domain.Entities;

namespace PSLAdministrativa.Data.EntityConfig
{
    public class TbDireitoConfig : IEntityTypeConfiguration<TbDireito>
    {
        public void Configure(EntityTypeBuilder<TbDireito> entity)
        {
            entity.HasKey(e => e.IdDireito)
                    .ForSqlServerIsClustered(false);

            entity.ToTable("Direito");

            entity.Property(e => e.IdDireito).HasColumnName("IdDireito");
            entity.Property(e => e.Descricao).HasColumnName("Descricao");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("IdUsuarioAtualizacao");
            entity.Property(e => e.DataAtualizacao).HasColumnName("DataAtualizacao");
        }
    }
}
