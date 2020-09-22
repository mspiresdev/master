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

        protected override void OnModelCreating(ModelBuilder mb)
        {
             base.OnModelCreating(mb);
            // Remove a plural automatico


            //modelBuilder.ApplyConfiguration(new LivroMap());
            //modelBuilder.ApplyConfiguration(new AutorMap());
            //modelBuilder.ApplyConfiguration(new AssuntoMap());

            mb.Entity<Livro>().ToTable("Livro");

            mb.Entity<Assunto>().ToTable("Assunto");

            mb.Entity<Autor>().ToTable("Autor");

            mb.Entity<LivroAutor>().ToTable("LivroAutor");

            mb.Entity<LivroAssunto>().ToTable("LivroAssunto");


            

            mb.Entity<LivroAssunto>().HasKey(k => new { k.Livro_Id, k.Assunto_Id });

            mb.Entity<LivroAssunto>()
                .HasOne<Livro>(sc => sc.Livro)
                .WithMany(s => s.LivroAssunto)
                .HasForeignKey(sc => sc.Livro_Id);


            mb.Entity<LivroAssunto>()
                .HasOne<Assunto>(sc => sc.Assunto)
                .WithMany(s => s.LivroAssunto)
                .HasForeignKey(sc => sc.Assunto_Id);


            mb.Entity<LivroAutor>().HasKey(k => new { k.Livro_Id, k.Autor_Id });

            mb.Entity<LivroAutor>()
                .HasOne<Livro>(sc => sc.Livro)
                .WithMany(s => s.LivroAutor)
                .HasForeignKey(sc => sc.Livro_Id);


            mb.Entity<LivroAutor>()
                .HasOne<Autor>(sc => sc.Autor)
                .WithMany(s => s.LivroAutors)
                .HasForeignKey(sc => sc.Autor_Id);



      //      mb.Entity<LivroAutor>()
      //         .HasKey(k => new { k.Livro_Id, k.Autor_Id })
      //     ;

      //      mb.Entity<LivroAutor>()
      //      .HasOne(s => s.Livro)
      //      .WithMany(s => s.Autors)
      //       .HasForeignKey(a => a.Livro_Id);
      //      ;

      //      mb.Entity<LivroAutor>()
      //       .HasOne(s => s.Autor)
      //       .WithMany()
      //    .HasForeignKey(a => a.Autor_Id);
      //      ;


      //      mb.Entity<LivroAutor>()
      //  .HasOne<Livro>(sc => sc.Livro)
      //  .WithMany(s => s.Autors)
      //  .HasForeignKey(sc => sc.Livro_Id);

      //      mb.Entity<LivroAssunto>()
      //.HasOne<Livro>(sc => sc.Livro)
      //.WithMany(s => s.Assuntos)
      //.HasForeignKey(sc => sc.Livro_Id);

        }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<LivroAssunto> LivroAssunto { get; set; }
        public DbSet<LivroAutor> LivroAutor { get; set; }
    }
}
