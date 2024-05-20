using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SICPC_API.Entities.Models;

public partial class SicpcContext : DbContext
{
    public SicpcContext(DbContextOptions<SicpcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Servicio> Servicio { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.Empresa)
                .HasMaxLength(50)
                .HasColumnName("empresa");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(500)
                .HasColumnName("mensaje");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(150)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(12)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio);

            entity.Property(e => e.DescripcionCorta)
                .HasMaxLength(250)
                .HasColumnName("descripcionCorta");
            entity.Property(e => e.DescripcionLarga)
                .HasMaxLength(500)
                .HasColumnName("descripcionLarga");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.Icon)
                .HasMaxLength(250)
                .HasColumnName("icon");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.Contrasena).HasMaxLength(500);
            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.Habilitado).HasDefaultValue(true);
            entity.Property(e => e.NombreCompleto).HasMaxLength(200);
            entity.Property(e => e.TelefonoMovil).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
