using Base.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Base.Infra.Mapeamentos
{
    public class LivroAutorMap : MapBase<LivroAutor>
    {
        public override void Configure(EntityTypeBuilder<LivroAutor> builder)
        {
            // Relacionamento N x N
            builder.HasOne(x => x.Livro)
                .WithMany(x => x.LivroAutors)
                .HasForeignKey("Livro_Id")
                .IsRequired();

            // Relacionamento N x N
            builder.HasOne(x => x.Autor)
                .WithMany(x => x.LivroAutors)
                .HasForeignKey("Autor_Id")
                .IsRequired();

           
        }
       
    }
}
