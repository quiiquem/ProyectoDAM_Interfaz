using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Intermodular_Gestion.Backend.Modelo;

[PrimaryKey("EstadoIdestado", "ProductoIdProducto")]
[Table("estado_has_producto")]
[Index("EstadoIdestado", Name = "fk_estado_has_producto_estado1_idx")]
[Index("ProductoIdProducto", Name = "fk_estado_has_producto_producto1_idx")]
public partial class EstadoHasProducto
{
    [Key]
    [Column("estado_idestado")]
    public int EstadoIdestado { get; set; }

    [Key]
    [Column("producto_ID_Producto")]
    public int ProductoIdProducto { get; set; }

    [ForeignKey("EstadoIdestado")]
    [InverseProperty("EstadoHasProductos")]
    public virtual Estado EstadoIdestadoNavigation { get; set; } = null!;
}
