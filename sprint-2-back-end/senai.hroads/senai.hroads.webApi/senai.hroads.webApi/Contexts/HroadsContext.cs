using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi.Domains;

#nullable disable

namespace senai.hroads.webApi.Contexts
{
    public partial class HroadsContext : DbContext
    {
        public HroadsContext()
        {
        }

        public HroadsContext(DbContextOptions<HroadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<ClasseHabilidade> ClasseHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Jogo> Jogos { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0KGDOK7; initial catalog=Hroads; user id=sa; pwd=senai@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__Classe__60FFF801CB16E3C0");

                entity.ToTable("Classe");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.NomeClasse)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClasseHabilidade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClasseHabilidade");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__ClasseHab__idCla__3E52440B");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__ClasseHab__idHab__3F466844");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__655F752896FF35CC");

                entity.ToTable("Habilidade");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Habilidad__idTip__3C69FB99");
            });

            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.HasKey(e => e.IdJogo)
                    .HasName("PK__Jogo__05C4E665BF044D7E");

                entity.ToTable("Jogo");

                entity.Property(e => e.IdJogo).HasColumnName("idJogo");

                entity.Property(e => e.NomeJogo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__E175C72E44934785");

                entity.ToTable("Personagem");

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.DataAtualizacao).HasColumnType("date");

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdJogo).HasColumnName("idJogo");

                entity.Property(e => e.NomePersonagem)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Personage__idCla__44FF419A");

                entity.HasOne(d => d.IdJogoNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdJogo)
                    .HasConstraintName("FK__Personage__idJog__440B1D61");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__Tipo__BDD0DFE1739055C7");

                entity.ToTable("Tipo");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.NomeTipo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
