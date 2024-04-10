using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Azure_Waters_backend.Models;

public partial class AzureWatersContext : DbContext
{
    public AzureWatersContext()
    {
    }

    public AzureWatersContext(DbContextOptions<AzureWatersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-N2FI4RE;Database=Azure_Waters;User Id=sa;Password=sa123456;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B8499B6054");

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuarios__6B0F5AE084F400A9").IsUnique();

            entity.Property(e => e.Contrasenna).HasMaxLength(10);
            entity.Property(e => e.NombreUsuario).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
