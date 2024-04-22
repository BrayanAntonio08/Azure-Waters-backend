using System;
using System.Collections.Generic;
using AW.AccesoDatos;
using AW.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aw.AccesoDatos;

public partial class AzureWatersContext : DbContext
{
    private string sqlConnString;
    public AzureWatersContext()
    {
        this.sqlConnString = ConexionDatos.CONECTION_PC;
        this.sqlConnString = ConexionDatos.CONECTION_LAPTOP;
    }

    public AzureWatersContext(DbContextOptions<AzureWatersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(this.sqlConnString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK_ID");

            entity.HasIndex(e => e.NombreUsuario, "UQ_NombreUsuario").IsUnique();

            entity.Property(e => e.Contrasenna).HasMaxLength(10);
            entity.Property(e => e.NombreUsuario).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
