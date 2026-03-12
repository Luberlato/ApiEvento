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

    public virtual DbSet<Eventos> Eventos { get; set; }

    public virtual DbSet<Palestrante> Palestrante { get; set; }

    public virtual DbSet<Participante> Participante { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Db_Eventos;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Eventos>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Eventos__1EEB5921EC0D2661");

            entity.Property(e => e.LocalRealizacao).HasMaxLength(255);
            entity.Property(e => e.Nome).HasMaxLength(150);

            entity.HasOne(d => d.Palestrante).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.PalestranteId)
                .HasConstraintName("FK__Eventos__Palestr__5AEE82B9");

            entity.HasOne(d => d.Participante).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.ParticipanteId)
                .HasConstraintName("FK__Eventos__Partici__59FA5E80");
        });

        modelBuilder.Entity<Palestrante>(entity =>
        {
            entity.HasKey(e => e.PalestranteId).HasName("PK__Palestra__404E969631AAA8D6");

            entity.Property(e => e.AreaDeAtuacao).HasMaxLength(100);
            entity.Property(e => e.Nome).HasMaxLength(150);
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.ParticipanteId).HasName("PK__Particip__E6DEAC5FCEEE6726");

            entity.HasIndex(e => e.Email, "UQ__Particip__A9D1053401403967").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Nome).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
