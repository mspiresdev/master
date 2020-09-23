using Base.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Base.Infra.Mapeamentos
{
    public class LivroAssuntoMap : MapBase<LivroAssunto>
    {
        public override void Configure(EntityTypeBuilder<LivroAssunto> builder)
        {
            // Relacionamento N x N
            builder.HasOne(x => x.Livro)
                .WithMany(x => x.LivroAssuntos)
                .HasForeignKey("Livro_Id")
                .IsRequired();

            // Relacionamento N x N
            builder.HasOne(x => x.Assunto)
                .WithMany(x => x.LivroAssuntos)
                .HasForeignKey("Assunto_Id")
                .IsRequired();


        }
       
    }
}
