using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class DotacionDbContext : DbContext
{
    public DotacionDbContext()
    {
    }

    public DotacionDbContext(DbContextOptions<DotacionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulo { get; set; }

    public virtual DbSet<Dotacion> Dotacion { get; set; }

    public virtual DbSet<EstadoDotacion> EstadoDotacion { get; set; }

    public virtual DbSet<Institucion> Institucion { get; set; }

    public virtual DbSet<Municipio> Municipio { get; set; }

    public virtual DbSet<ObservacionImagen> ObservacionImagen { get; set; }

    public virtual DbSet<Sede> Sede { get; set; }

    public virtual DbSet<SeguimientoDotacion> SeguimientoDotacion { get; set; }

    public virtual DbSet<SeguimientoObservacion> SeguimientoObservacion { get; set; }

    public virtual DbSet<Tipodotacion> Tipodotacion { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=gondola.proxy.rlwy.net;port=59479;database=p_dotacion;user=root;password=jTdwWMTOhpvGryZhoeAvAoJiTpcpzepi", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.3.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.IdArticulo).HasName("PRIMARY");

            entity.ToTable("ARTICULO");

            entity.Property(e => e.IdArticulo).HasColumnName("ID_ARTICULO");
            entity.Property(e => e.DescripcionArticulo)
                .HasMaxLength(45)
                .HasColumnName("DESCRIPCION_ARTICULO");
        });

        modelBuilder.Entity<Dotacion>(entity =>
        {
            entity.HasKey(e => e.IdDotacion).HasName("PRIMARY");

            entity.ToTable("DOTACION");

            entity.HasIndex(e => e.FkIdArticulo, "FK_ARTICULOSEDE_ARTICULO1_idx");

            entity.HasIndex(e => e.FkIdSede, "FK_ARTICULOSEDE_SEDE1_idx");

            entity.HasIndex(e => e.FkIdTipodotacion, "FK_DOTACION_TIPODOTACION1_idx");

            entity.HasIndex(e => e.FkIdEstadoActual, "FK_ESTADO_ACTUAL");

            entity.Property(e => e.IdDotacion).HasColumnName("ID_DOTACION");
            entity.Property(e => e.CantidadDotacion).HasColumnName("CANTIDAD_DOTACION");
            entity.Property(e => e.FkIdArticulo).HasColumnName("FK_ID_ARTICULO");
            entity.Property(e => e.FkIdEstadoActual).HasColumnName("FK_ID_ESTADO_ACTUAL");
            entity.Property(e => e.FkIdSede).HasColumnName("FK_ID_SEDE");
            entity.Property(e => e.FkIdTipodotacion).HasColumnName("FK_ID_TIPODOTACION");

            entity.HasOne(d => d.FkIdArticuloNavigation).WithMany(p => p.Dotacion)
                .HasForeignKey(d => d.FkIdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARTICULOSEDE_ARTICULO1");

            entity.HasOne(d => d.FkIdEstadoActualNavigation).WithMany(p => p.Dotacion)
                .HasForeignKey(d => d.FkIdEstadoActual)
                .HasConstraintName("FK_ESTADO_ACTUAL");

            entity.HasOne(d => d.FkIdSedeNavigation).WithMany(p => p.Dotacion)
                .HasForeignKey(d => d.FkIdSede)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARTICULOSEDE_SEDE1");

            entity.HasOne(d => d.FkIdTipodotacionNavigation).WithMany(p => p.Dotacion)
                .HasForeignKey(d => d.FkIdTipodotacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DOTACION_TIPODOTACION1");
        });

        modelBuilder.Entity<EstadoDotacion>(entity =>
        {
            entity.HasKey(e => e.IdEstadoDotacion).HasName("PRIMARY");

            entity.ToTable("ESTADO_DOTACION");

            entity.Property(e => e.IdEstadoDotacion).HasColumnName("ID_ESTADO_DOTACION");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_ESTADO");
        });

        modelBuilder.Entity<Institucion>(entity =>
        {
            entity.HasKey(e => e.IdInstitucion).HasName("PRIMARY");

            entity.ToTable("INSTITUCION");

            entity.HasIndex(e => e.FkIdMunicipio, "FK_INSTITUCION_MUNICIPIO_idx");

            entity.Property(e => e.IdInstitucion).HasColumnName("ID_INSTITUCION");
            entity.Property(e => e.CalendarioInstitucion)
                .HasMaxLength(45)
                .HasColumnName("CALENDARIO_INSTITUCION");
            entity.Property(e => e.CodigodaneInstitucion)
                .HasMaxLength(45)
                .HasColumnName("CODIGODANE_INSTITUCION");
            entity.Property(e => e.FkIdMunicipio).HasColumnName("FK_ID_MUNICIPIO");
            entity.Property(e => e.NombreInstitucion)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_INSTITUCION");

            entity.HasOne(d => d.FkIdMunicipioNavigation).WithMany(p => p.Institucion)
                .HasForeignKey(d => d.FkIdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSTITUCION_MUNICIPIO");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PRIMARY");

            entity.ToTable("MUNICIPIO");

            entity.Property(e => e.IdMunicipio).HasColumnName("ID_MUNICIPIO");
            entity.Property(e => e.LatitudMunicipio)
                .HasMaxLength(50)
                .HasColumnName("LATITUD_MUNICIPIO");
            entity.Property(e => e.LongitudMunicipio)
                .HasMaxLength(50)
                .HasColumnName("LONGITUD_MUNICIPIO");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(45)
                .HasColumnName("NOMBRE_MUNICIPIO");
        });

        modelBuilder.Entity<ObservacionImagen>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PRIMARY");

            entity.ToTable("OBSERVACION_IMAGEN");

            entity.HasIndex(e => e.FkIdObservacion, "FK_ID_OBSERVACION");

            entity.Property(e => e.IdImagen).HasColumnName("ID_IMAGEN");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.FkIdObservacion).HasColumnName("FK_ID_OBSERVACION");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(255)
                .HasColumnName("URL_IMAGEN");

            entity.HasOne(d => d.FkIdObservacionNavigation).WithMany(p => p.ObservacionImagen)
                .HasForeignKey(d => d.FkIdObservacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OBSERVACION_IMAGEN_ibfk_1");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.IdSede).HasName("PRIMARY");

            entity.ToTable("SEDE");

            entity.HasIndex(e => e.FkIdInstitucion, "FK_SEDE_INSTITUCION1_idx");

            entity.Property(e => e.IdSede).HasColumnName("ID_SEDE");
            entity.Property(e => e.CodigodaneSede)
                .HasMaxLength(45)
                .HasColumnName("CODIGODANE_SEDE");
            entity.Property(e => e.DireccionSede)
                .HasMaxLength(45)
                .HasColumnName("DIRECCION_SEDE");
            entity.Property(e => e.FkIdInstitucion).HasColumnName("FK_ID_INSTITUCION");
            entity.Property(e => e.LatitudSede)
                .HasMaxLength(45)
                .HasColumnName("LATITUD_SEDE");
            entity.Property(e => e.LongitudSede)
                .HasMaxLength(45)
                .HasColumnName("LONGITUD_SEDE");
            entity.Property(e => e.NombreSede)
                .HasMaxLength(60)
                .HasColumnName("NOMBRE_SEDE");
            entity.Property(e => e.ZonaSede)
                .HasMaxLength(45)
                .HasColumnName("ZONA_SEDE");

            entity.HasOne(d => d.FkIdInstitucionNavigation).WithMany(p => p.Sede)
                .HasForeignKey(d => d.FkIdInstitucion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SEDE_INSTITUCION1");
        });

        modelBuilder.Entity<SeguimientoDotacion>(entity =>
        {
            entity.HasKey(e => e.IdSeguimiento).HasName("PRIMARY");

            entity.ToTable("SEGUIMIENTO_DOTACION");

            entity.HasIndex(e => e.FkIdDotacion, "FK_ID_DOTACION");

            entity.HasIndex(e => e.FkIdEstado, "FK_ID_ESTADO");

            entity.Property(e => e.IdSeguimiento).HasColumnName("ID_SEGUIMIENTO");
            entity.Property(e => e.CantidadRecibida).HasColumnName("CANTIDAD_RECIBIDA");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.FkIdDotacion).HasColumnName("FK_ID_DOTACION");
            entity.Property(e => e.FkIdEstado).HasColumnName("FK_ID_ESTADO");

            entity.HasOne(d => d.FkIdDotacionNavigation).WithMany(p => p.SeguimientoDotacion)
                .HasForeignKey(d => d.FkIdDotacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SEGUIMIENTO_DOTACION_ibfk_1");

            entity.HasOne(d => d.FkIdEstadoNavigation).WithMany(p => p.SeguimientoDotacion)
                .HasForeignKey(d => d.FkIdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SEGUIMIENTO_DOTACION_ibfk_2");
        });

        modelBuilder.Entity<SeguimientoObservacion>(entity =>
        {
            entity.HasKey(e => e.IdObservacion).HasName("PRIMARY");

            entity.ToTable("SEGUIMIENTO_OBSERVACION");

            entity.HasIndex(e => e.FkIdSeguimiento, "FK_ID_SEGUIMIENTO");

            entity.Property(e => e.IdObservacion).HasColumnName("ID_OBSERVACION");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.FkIdSeguimiento).HasColumnName("FK_ID_SEGUIMIENTO");
            entity.Property(e => e.Texto)
                .HasColumnType("text")
                .HasColumnName("TEXTO");

            entity.HasOne(d => d.FkIdSeguimientoNavigation).WithMany(p => p.SeguimientoObservacion)
                .HasForeignKey(d => d.FkIdSeguimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SEGUIMIENTO_OBSERVACION_ibfk_1");
        });

        modelBuilder.Entity<Tipodotacion>(entity =>
        {
            entity.HasKey(e => e.IdTipodotacion).HasName("PRIMARY");

            entity.ToTable("TIPODOTACION");

            entity.Property(e => e.IdTipodotacion).HasColumnName("ID_TIPODOTACION");
            entity.Property(e => e.NombreTipodotacion)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_TIPODOTACION");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("USUARIO");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.ContraseniaUsuario)
                .HasMaxLength(200)
                .HasColumnName("CONTRASENIA_USUARIO");
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(200)
                .HasColumnName("CORREO_USUARIO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
