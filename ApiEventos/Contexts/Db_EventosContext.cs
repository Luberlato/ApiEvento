using System;
using System.Collections.Generic;
using ApiEventos.Domains;
using Microsoft.EntityFrameworkCore;

namespace ApiEventos.Contexts;

public partial class Db_EventosContext : DbContext
{
    public Db_EventosContext()
    {
    }

    public Db_EventosContext(DbContextOptions<Db_EventosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evento> Evento { get; set; }

    public virtual DbSet<Inscricao> Inscricao { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Db_Eventos;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Evento__1EEB5921BD51A223");

            entity.Property(e => e.LocalRealizacao).HasMaxLength(255);
            entity.Property(e => e.Nome).HasMaxLength(150);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Evento)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Evento__UsuarioI__52593CB8");
        });

        modelBuilder.Entity<Inscricao>(entity =>
        {
            entity.HasKey(e => e.InscricaoId).HasName("PK__Inscrica__CD089DAE0984A1E9");

            entity.HasOne(d => d.Evento).WithMany(p => p.Inscricao)
                .HasForeignKey(d => d.EventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inscricao__Event__5629CD9C");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Inscricao)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inscricao__Usuar__5535A963");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B87E08135F");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534ACDAE62B").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Nome).HasMaxLength(150);
            entity.Property(e => e.Senha).HasMaxLength(32);
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
