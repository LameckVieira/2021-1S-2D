using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_InLock_webApi_DBFirst.Domains;

#nullable disable

// Scaffol-DbContext "Data Source=SERVIDOR; initial catalog=InLock_Games; user Id=sa; pwd=senai@132;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domains -ContextDir Contexts -Context InLockContext

// Comando:                                 Scaffold-DbContext
// String de conexão:                       "Data Source=SERVIDOR; initial catalog=InLock_Games; user Id=sa; pwd=senai@132;"
// Provedor utilizado:                      Microsoft.EntityFrameworkCore.SqlServer
// Nome da pasta onde ficarão os domínios:  -OutputDir Domains
// Nome da pasta onde ficarão os contextos: -ContextDir Contexts
// Nome da classe de contexto:              -Context InLockContext


namespace senai_InLock_webApi_DBFirst.Contexts
{
    public partial class InLockContext : DbContext
    {
        public InLockContext()
        {
        }

        public InLockContext(DbContextOptions<InLockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudio> Estudios { get; set; }
        public virtual DbSet<Jogo> Jogos { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SP7RV1S\\SQLEXPRESS; initial catalog=InLock_Games; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Estudio>(entity =>
            {
                entity.HasKey(e => e.IdEstudio)
                    .HasName("PK__Estudios__0C3B43551C07C6FB");

                entity.HasIndex(e => e.NomeEstudio, "UQ__Estudios__112A56901CB58120")
                    .IsUnique();

                entity.Property(e => e.NomeEstudio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.HasKey(e => e.IdJogo)
                    .HasName("PK__Jogos__69E085134D404C08");

                entity.HasIndex(e => e.NomeJogo, "UQ__Jogos__89AF93E41B5A6FEC")
                    .IsUnique();

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.NomeJogo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdEstudioNavigation)
                    .WithMany(p => p.Jogos)
                    .HasForeignKey(d => d.IdEstudio)
                    .HasConstraintName("FK__Jogos__IdEstudio__412EB0B6");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TiposUsu__CA04062B932A8A3A");

                entity.ToTable("TiposUsuario");

                entity.HasIndex(e => e.Titulo, "UQ__TiposUsu__7B406B567AE9034E")
                    .IsUnique();

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97568762A0");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534DE91B974")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__IdTipo__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
