using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Intermodular_Gestion.Backend.Modelo;

public partial class ProyectoIntermodularContext : DbContext
{
    public ProyectoIntermodularContext()
    {
    }

    public ProyectoIntermodularContext(DbContextOptions<ProyectoIntermodularContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<EstadoHasProducto> EstadoHasProductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;port=1500;database=proyecto_intermodular;user=root;password=oracle");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategorias).HasName("PRIMARY");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.UsuariosIdusuario).HasName("PRIMARY");

            entity.HasOne(d => d.UsuariosIdusuarioNavigation).WithOne(p => p.Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cliente_USUARIOS1");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => new { e.Idcompra, e.ProductoIdProducto }).HasName("PRIMARY");

            entity.Property(e => e.Idcompra).ValueGeneratedOnAdd();

            entity.HasOne(d => d.ClienteUsuariosIdusuarioNavigation).WithMany(p => p.Compras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_compra_cliente1");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Idestado).HasName("PRIMARY");
        });

        modelBuilder.Entity<EstadoHasProducto>(entity =>
        {
            entity.HasKey(e => new { e.EstadoIdestado, e.ProductoIdProducto }).HasName("PRIMARY");

            entity.HasOne(d => d.EstadoIdestadoNavigation).WithMany(p => p.EstadoHasProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estado_has_producto_estado1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => new { e.IdProducto, e.UbicacionIdUbicacion, e.CategoriasIdcategorias }).HasName("PRIMARY");

            entity.Property(e => e.IdProducto).ValueGeneratedOnAdd();

            entity.HasOne(d => d.CategoriasIdcategoriasNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_categorias1");

            entity.HasOne(d => d.UbicacionIdUbicacionNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_Ubicacion1");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRoles).HasName("PRIMARY");
        });


        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("PRIMARY");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
