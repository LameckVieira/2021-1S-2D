using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_gufi_webApi.Domains;

#nullable disable

// Documentação do EF Core
// https://docs.microsoft.com/pt-br/ef/core/managing-schemas/scaffolding?tabs=vs

/*
    Dependências do EF Core

    Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.SqlServer.Design
    Microsoft.EntityFrameworkCore.Tools
*/

// Scaffold-DbContext "Data Source=DESKTOP-SP7RV1S\SQLEXPRESS; Initial Catalog=Gufi_tarde; user id=sa; pwd=senai@132;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domains -ContextDir Context -Context GufiContext

// Comando:                                     Scaffold-DbContext
// String de conexão:                           "Data Source=DESKTOP-SP7RV1S\SQLEXPRESS; Initial Catalog=Gufi_tarde; user id=sa; pwd=senai@132;"
// Provedor utilizado:                          Microsoft.EntityFrameworkCore.SqlServer
// Nome da pasta onde ficarão os domínios:      -OutputDir Domains
// Nome da pasta onde ficarão os contextos:     -ContextDir Contexts
// Nome do arquivo/classe de contexto:          -Context GufiContext


namespace senai_gufi_webApi.Contexts
{
    public partial class GufiContext : DbContext
    {
        public GufiContext()
        {
        }

        public GufiContext(DbContextOptions<GufiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Instituico> Instituicoes { get; set; }
        public virtual DbSet<Presenca> Presencas { get; set; }
        public virtual DbSet<TiposEvento> TiposEventos { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SP7RV1S\\SQLEXPRESS; Initial Catalog=Gufi_tarde; user id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__eventos__C8DC7BDA9E2E3C6A");

                entity.ToTable("eventos");

                entity.Property(e => e.IdEvento).HasColumnName("idEvento");

                entity.Property(e => e.AcessoLivre)
                    .HasColumnName("acessoLivre")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataEvento)
                    .HasColumnType("date")
                    .HasColumnName("dataEvento");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.IdTipoEvento).HasColumnName("idTipoEvento");

                entity.Property(e => e.NomeEvento)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nomeEvento");

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__eventos__idInsti__33D4B598");

                entity.HasOne(d => d.IdTipoEventoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdTipoEvento)
                    .HasConstraintName("FK__eventos__idTipoE__32E0915F");
            });

            modelBuilder.Entity<Instituico>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__institui__8EA7AB0048359710");

                entity.ToTable("instituicoes");

                entity.HasIndex(e => e.Cnpj, "UQ__institui__35BD3E48E2EC5D00")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco, "UQ__institui__9456D40652EE99EF")
                    .IsUnique();

                entity.HasIndex(e => e.NomeFantasia, "UQ__institui__E7ADFC70F782BE65")
                    .IsUnique();

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpj")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");
            });

            modelBuilder.Entity<Presenca>(entity =>
            {
                entity.HasKey(e => e.IdPresenca)
                    .HasName("PK__presenca__44CEA42776633B38");

                entity.ToTable("presencas");

                entity.Property(e => e.IdPresenca).HasColumnName("idPresenca");

                entity.Property(e => e.IdEvento).HasColumnName("idEvento");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Situacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("situacao");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__presencas__idEve__38996AB5");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__presencas__idUsu__37A5467C");
            });

            modelBuilder.Entity<TiposEvento>(entity =>
            {
                entity.HasKey(e => e.IdTipoEvento)
                    .HasName("PK__tiposEve__09EED93A4CF8B927");

                entity.ToTable("tiposEventos");

                entity.HasIndex(e => e.TituloTipoEvento, "UQ__tiposEve__D2A1CBBB7A7E4B6D")
                    .IsUnique();

                entity.Property(e => e.IdTipoEvento).HasColumnName("idTipoEvento");

                entity.Property(e => e.TituloTipoEvento)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoEvento");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tiposUsu__03006BFF86C7688E");

                entity.ToTable("tiposUsuarios");

                entity.HasIndex(e => e.TituloTipoUsuario, "UQ__tiposUsu__C6B29FC3611BABD6")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__645723A6F6679E0B");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E6164BEEC3CB9")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuarios__idTipo__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
