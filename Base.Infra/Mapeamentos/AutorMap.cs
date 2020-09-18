using Base.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Base.Infra.Mapeamentos
{
    public class AutorMap : MapBase<Autor>
    {
        public override void Configure(EntityTypeBuilder<Autor> builder)
        {
            base.Configure(builder);
            builder.ToTable("autor");
            builder.Property(c => c.Nome).IsRequired().HasColumnName("Nome").HasMaxLength(100);
            
        }
    }
}
