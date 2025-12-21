using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[PrimaryKey("IdProducto", "UbicacionIdUbicacion")]
[Table("producto")]
[Index("Nombre", Name = "Nombre_UNIQUE", IsUnique = true)]
[Index("EmpleadosIdEmpleado", Name = "fk_PRODUCTO_EMPLEADOS1_idx")]
[Index("UbicacionIdUbicacion", Name = "fk_producto_Ubicacion1_idx")]
public partial class Producto
{
    [Key]
    [Column("ID_Producto")]
    public int IdProducto { get; set; }

    [StringLength(30)]
    public string Nombre { get; set; } = null!;

    [Precision(10, 0)]
    public decimal Precio { get; set; }

    [Column("Cantidad_Stock")]
    public int? CantidadStock { get; set; }

    [Column("Fecha_Ingreso", TypeName = "date")]
    public DateTime? FechaIngreso { get; set; }

    [Column("Ubicacion_Almacen")]
    [StringLength(45)]
    public string? UbicacionAlmacen { get; set; }

    [StringLength(45)]
    public string Categoria { get; set; } = null!;

    [Column("EMPLEADOS_ID_Empleado")]
    public int? EmpleadosIdEmpleado { get; set; }

    [Key]
    [Column("Ubicacion_idUbicacion")]
    public int UbicacionIdUbicacion { get; set; }

    [ForeignKey("UbicacionIdUbicacion")]
    [InverseProperty("Productos")]
    public virtual Ubicacion UbicacionIdUbicacionNavigation { get; set; } = null!;

    [ForeignKey("ProductoIdProducto, ProductoUbicacionIdUbicacion")]
    [InverseProperty("Productos")]
    public virtual ICollection<Ventum> VentaIdventa { get; set; } = new List<Ventum>();
}
