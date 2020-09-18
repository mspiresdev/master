using Base.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Base.Infra.Mapeamentos
{
    public class AssuntoMap : MapBase<Assunto>
    {
        public override void Configure(EntityTypeBuilder<Assunto> builder)
        {
            base.Configure(builder);
            builder.ToTable("assunto");
            builder.Property(c => c.Descricao).IsRequired().HasColumnName("Descricao").HasMaxLength(100);
            
        }
    }
}
