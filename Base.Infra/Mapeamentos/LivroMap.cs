using Base.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Base.Infra.Mapeamentos
{
    public class LivroMap : MapBase<Livro>
    {
        public override void Configure(EntityTypeBuilder<Livro> builder)
        {
            base.Configure(builder);
            builder.ToTable("livro");
           
            builder.Property(c => c.Titulo).IsRequired().HasColumnName("Titulo").HasMaxLength(40);
            builder.Property(c => c.Editora).IsRequired().HasColumnName("Editora").HasMaxLength(40);
            builder.Property(c => c.Edicao).IsRequired().HasColumnName("Edicao");
            builder.Property(c => c.AnoPublicacao).IsRequired().HasColumnName("AnoPublicacao").HasMaxLength(40);
            builder.Property(c => c.Preco).HasColumnName("Preco");

            
        }
       
    }
}
