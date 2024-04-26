using System;
using System.Collections.Generic;
using AW.AccesoDatos;
using Microsoft.EntityFrameworkCore;

namespace Azure_Waters_backend.Models;

public partial class AzureWatersContext : DbContext
{
    private string sqlConnString;
    public AzureWatersContext()
    {
        this.sqlConnString = ConexionDatos.ACTIVE_CONECTION;
        //this.sqlConnString = ConexionDatos.CONECTION_LAPTOP;
    }

    public AzureWatersContext(DbContextOptions<AzureWatersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anuncio> Anuncio { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Facilidad> Facilidad { get; set; }

    public virtual DbSet<Habitacion> Habitacion { get; set; }

    public virtual DbSet<Imagen> Imagen { get; set; }

    public virtual DbSet<Pagina> Pagina { get; set; }

    public virtual DbSet<Reserva> Reserva { get; set; }

    public virtual DbSet<Temporada> Temporada { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacion { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(this.sqlConnString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anuncio>(entity =>
        {
            entity.HasKey(e => e.AnuncioId).HasName("PK__Id__Anuncio");

            entity.Property(e => e.AnuncioId).HasColumnName("anuncio_id");
            entity.Property(e => e.ImagenId).HasColumnName("imagen_id");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.Imagen).WithMany(p => p.Anuncio)
                .HasForeignKey(d => d.ImagenId)
                .HasConstraintName("FK__Imagen_Anuncio");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PF__Id__Cliente");

            entity.Property(e => e.IdCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_cliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TarjetaCredito)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tarjeta_credito");
        });

        modelBuilder.Entity<Facilidad>(entity =>
        {
            entity.HasKey(e => e.FacilidadId).HasName("PK__Id__Facilidad");

            entity.Property(e => e.FacilidadId).HasColumnName("facilidad_id");
            entity.Property(e => e.ImagenId).HasColumnName("imagen_id");
            entity.Property(e => e.Texto)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("texto");

            entity.HasOne(d => d.Imagen).WithMany(p => p.Facilidad)
                .HasForeignKey(d => d.ImagenId)
                .HasConstraintName("FK__Imagen__Facilidad");
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Id__Habitacion");

            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.Activa).HasColumnName("activa");
            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Reservada).HasColumnName("reservada");
            entity.Property(e => e.Revision).HasColumnName("revision");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Habitacion)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK__Tipo__Habitacion");
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Id__Imagen");

            entity.HasIndex(e => e.Url, "UQ__Link").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("alt");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasMany(d => d.Pagina).WithMany(p => p.Imagen)
                .UsingEntity<Dictionary<string, object>>(
                    "ImagenPagina",
                    r => r.HasOne<Pagina>().WithMany()
                        .HasForeignKey("PaginaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Id__Pagina__Imagen"),
                    l => l.HasOne<Imagen>().WithMany()
                        .HasForeignKey("ImagenId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Id__Imagen__Pagina"),
                    j =>
                    {
                        j.HasKey("ImagenId", "PaginaId").HasName("PK__Imagen__Pagina");
                        j.ToTable("Imagen_Pagina");
                        j.IndexerProperty<int>("ImagenId").HasColumnName("imagen_id");
                        j.IndexerProperty<int>("PaginaId").HasColumnName("pagina_id");
                    });
        });

        modelBuilder.Entity<Pagina>(entity =>
        {
            entity.HasKey(e => e.PaginaId).HasName("PK__Id__Pagina");

            entity.Property(e => e.PaginaId)
                .ValueGeneratedNever()
                .HasColumnName("pagina_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Texto)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("texto");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Id_Reserva");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.Guid)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("guid");
            entity.Property(e => e.IdCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_cliente");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reserva)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Cliente__Reserva");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reserva)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__Habitacion__Reserva");
        });

        modelBuilder.Entity<Temporada>(entity =>
        {
            entity.HasKey(e => e.IdTemporada).HasName("PK__Id__Temporada");

            entity.Property(e => e.IdTemporada).HasColumnName("id_temporada");
            entity.Property(e => e.Descuento)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("descuento");
            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Temporada)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TipoHabitacion__Temporada");
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__Id__TipoHabitacion");

            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Id__Usuario");

            entity.HasIndex(e => e.NombreUsuario, "UQ__NombreUsuario").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contrasenna)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contrasenna");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
