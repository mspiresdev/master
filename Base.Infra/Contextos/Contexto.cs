using Base.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Base.Infra.Mapeamentos;

namespace Base.Infra.Contextos
{
    public class Contexto : DbContext
    {
        
        public IDbContextTransaction Transaction { get; private set; }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
            if (Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public IDbContextTransaction InitTransacao()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }


        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Salvar();
            Commit();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new AssuntoMap());

            modelBuilder.Entity<LivroAssunto>()
        .HasKey(pc => new { pc.Livro_Id, pc.Assunto_Id });

            modelBuilder.Entity<LivroAssunto>()
                .HasOne(pc => pc.Livro)
                .WithMany(p => p.LAssuntos)
                .HasForeignKey(pc => pc.Id);

            modelBuilder.Entity<LivroAssunto>()
                .HasOne(pc => pc.Assunto)
                .WithMany(c => c.LAssuntos)
                .HasForeignKey(pc => pc.Id);

            modelBuilder.Entity<LivroAutor>()
       .HasKey(pc => new { pc.Livro_Id, pc.Autor_Id });

            modelBuilder.Entity<LivroAutor>()
                .HasOne(pc => pc.Livro)
                .WithMany(p => p.LAutors)
                .HasForeignKey(pc => pc.Id);

            modelBuilder.Entity<LivroAutor>()
                .HasOne(pc => pc.Autor)
                .WithMany(c => c.LAutors)
                .HasForeignKey(pc => pc.Id);

        }
      
    }
}
