using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Intermodular_Gestion.Backend.Modelo;

[PrimaryKey("Idcompra", "ProductoIdProducto")]
[Table("compra")]
[Index("ClienteUsuariosIdusuario", Name = "fk_compra_cliente1_idx")]
[Index("ProductoIdProducto", Name = "fk_compra_producto1_idx")]
public partial class Compra
{
    [Key]
    [Column("idcompra")]
    public int Idcompra { get; set; }

    [Column("cliente_USUARIOS_IDUsuario")]
    public int ClienteUsuariosIdusuario { get; set; }

    [Column("precio_total")]
    [Precision(10, 0)]
    public decimal PrecioTotal { get; set; }

    [Column("fecha_compra", TypeName = "date")]
    public DateTime FechaCompra { get; set; }

    [Key]
    [Column("producto_ID_Producto")]
    public int ProductoIdProducto { get; set; }

    [Column("cantidad_figuras")]
    public int CantidadFiguras { get; set; }

    [ForeignKey("ClienteUsuariosIdusuario")]
    [InverseProperty("Compras")]
    public virtual Cliente ClienteUsuariosIdusuarioNavigation { get; set; } = null!;
}
