using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

public partial class EnriqueMinguetProyectoContext : DbContext
{
    public EnriqueMinguetProyectoContext()
    {
    }

    public EnriqueMinguetProyectoContext(DbContextOptions<EnriqueMinguetProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<EstadoHasProducto> EstadoHasProductos { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Jefe> Jeves { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VentaHasCompra> VentaHasCompras { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;port=1500;database=enrique-minguet-proyecto;user=root;password=oracle");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategorias).HasName("PRIMARY");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => new { e.Dni, e.UsuariosIdusuario }).HasName("PRIMARY");

            entity.HasOne(d => d.UsuariosIdusuarioNavigation).WithMany(p => p.Clientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cliente_USUARIOS1");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => new { e.Idcompra, e.ProductoIdProducto, e.ClienteDni, e.CategoriasIdcategorias }).HasName("PRIMARY");

            entity.Property(e => e.Idcompra).ValueGeneratedOnAdd();

            entity.HasOne(d => d.CategoriasIdcategoriasNavigation).WithMany(p => p.Compras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_compra_categorias1");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => new { e.IdEmpleado, e.JefeIdJefe, e.JefeEmpleadosIdEmpleado, e.CompraIdcompra, e.CompraProductoIdProducto, e.CompraClienteDni, e.CompraClienteCompranIdcompra }).HasName("PRIMARY");

            entity.Property(e => e.IdEmpleado).ValueGeneratedOnAdd();

            entity.HasOne(d => d.JefeEmpleadosIdEmpleadoNavigation).WithMany(p => p.Empleados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleados_jefe1");
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

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => new { e.Idfactura, e.CompraIdcompra, e.CompraProductoIdProducto, e.CompraClienteDni, e.CompraClienteCompranIdcompra }).HasName("PRIMARY");
        });

        modelBuilder.Entity<Jefe>(entity =>
        {
            entity.HasKey(e => e.EmpleadosIdEmpleado).HasName("PRIMARY");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Idpermisos).HasName("PRIMARY");

            entity.HasMany(d => d.RolesIdroles).WithMany(p => p.PermisosIdpermisos)
                .UsingEntity<Dictionary<string, object>>(
                    "PermisosHasRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RolesIdroles")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_permisos_has_roles_roles1"),
                    l => l.HasOne<Permiso>().WithMany()
                        .HasForeignKey("PermisosIdpermisos")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_permisos_has_roles_permisos1"),
                    j =>
                    {
                        j.HasKey("PermisosIdpermisos", "RolesIdroles").HasName("PRIMARY");
                        j.ToTable("permisos_has_roles");
                        j.HasIndex(new[] { "PermisosIdpermisos" }, "fk_permisos_has_roles_permisos1_idx");
                        j.HasIndex(new[] { "RolesIdroles" }, "fk_permisos_has_roles_roles1_idx");
                        j.IndexerProperty<int>("PermisosIdpermisos").HasColumnName("permisos_idpermisos");
                        j.IndexerProperty<int>("RolesIdroles").HasColumnName("roles_idroles");
                    });
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => new { e.IdProducto, e.UbicacionIdUbicacion }).HasName("PRIMARY");

            entity.Property(e => e.IdProducto).ValueGeneratedOnAdd();

            entity.HasOne(d => d.UbicacionIdUbicacionNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_Ubicacion1");

            entity.HasMany(d => d.VentaIdventa).WithMany(p => p.Productos)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductoHasVentum",
                    r => r.HasOne<Ventum>().WithMany()
                        .HasForeignKey("VentaIdventa")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_producto_has_venta_venta1"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("ProductoIdProducto", "ProductoUbicacionIdUbicacion")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_producto_has_venta_producto1"),
                    j =>
                    {
                        j.HasKey("ProductoIdProducto", "ProductoUbicacionIdUbicacion", "VentaIdventa").HasName("PRIMARY");
                        j.ToTable("producto_has_venta");
                        j.HasIndex(new[] { "ProductoIdProducto", "ProductoUbicacionIdUbicacion" }, "fk_producto_has_venta_producto1_idx");
                        j.HasIndex(new[] { "VentaIdventa" }, "fk_producto_has_venta_venta1_idx");
                        j.IndexerProperty<int>("ProductoIdProducto").HasColumnName("producto_ID_Producto");
                        j.IndexerProperty<int>("ProductoUbicacionIdUbicacion").HasColumnName("producto_Ubicacion_idUbicacion");
                        j.IndexerProperty<int>("VentaIdventa").HasColumnName("venta_idventa");
                    });
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Idroles).HasName("PRIMARY");

            entity.HasOne(d => d.UsuariosIdusuarioNavigation).WithMany(p => p.Roles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_roles_USUARIOS1");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("PRIMARY");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PRIMARY");
        });

        modelBuilder.Entity<VentaHasCompra>(entity =>
        {
            entity.HasKey(e => new { e.VentaIdventa, e.CompraIdcompra, e.CompraProductoIdProducto, e.CompraClienteDni, e.CompraClienteCompranIdcompra }).HasName("PRIMARY");

            entity.HasOne(d => d.VentaIdventaNavigation).WithMany(p => p.VentaHasCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_venta_has_compra_venta1");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.Idventa).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
