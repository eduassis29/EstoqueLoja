using EstoqueLoja.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueLoja.Infra.Data.EntitiesConfiguration {
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario> {
        public void Configure(EntityTypeBuilder<Usuario> builder) {
            builder.HasKey(x => x.IdUse);
            builder.Property(x => x.EmailUse).HasMaxLength(100).IsRequired();
            builder.Property(x => x.NomeUse).HasMaxLength(100).IsRequired();
        }
    }
}
