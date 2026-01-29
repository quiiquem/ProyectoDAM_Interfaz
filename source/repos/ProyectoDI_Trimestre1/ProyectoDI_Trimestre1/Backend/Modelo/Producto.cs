using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Intermodular_Gestion.Backend.Modelo;

[PrimaryKey("IdProducto", "UbicacionIdUbicacion", "CategoriasIdcategorias")]
[Table("producto")]
[Index("Nombre", Name = "Nombre_UNIQUE", IsUnique = true)]
[Index("UbicacionIdUbicacion", Name = "fk_producto_Ubicacion1_idx")]
[Index("CategoriasIdcategorias", Name = "fk_producto_categorias1_idx")]
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

    [Key]
    [Column("Ubicacion_idUbicacion")]
    public int UbicacionIdUbicacion { get; set; }

    [Key]
    [Column("categorias_idcategorias")]
    public int CategoriasIdcategorias { get; set; }

    [ForeignKey("CategoriasIdcategorias")]
    [InverseProperty("Productos")]
    public virtual Categoria CategoriasIdcategoriasNavigation { get; set; } = null!;

    [ForeignKey("UbicacionIdUbicacion")]
    [InverseProperty("Productos")]
    public virtual Ubicacion UbicacionIdUbicacionNavigation { get; set; } = null!;
}
