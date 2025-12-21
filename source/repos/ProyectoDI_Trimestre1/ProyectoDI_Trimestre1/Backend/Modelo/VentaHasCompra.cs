using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[PrimaryKey("VentaIdventa", "CompraIdcompra", "CompraProductoIdProducto", "CompraClienteDni", "CompraClienteCompranIdcompra")]
[Table("venta_has_compra")]
[Index("CompraIdcompra", "CompraProductoIdProducto", "CompraClienteDni", "CompraClienteCompranIdcompra", Name = "fk_venta_has_compra_compra1_idx")]
[Index("VentaIdventa", Name = "fk_venta_has_compra_venta1_idx")]
public partial class VentaHasCompra
{
    [Key]
    [Column("venta_idventa")]
    public int VentaIdventa { get; set; }

    [Key]
    [Column("compra_IDCompra")]
    public int CompraIdcompra { get; set; }

    [Key]
    [Column("compra_PRODUCTO_ID_Producto")]
    public int CompraProductoIdProducto { get; set; }

    [Key]
    [Column("compra_cliente_DNI")]
    [StringLength(9)]
    public string CompraClienteDni { get; set; } = null!;

    [Key]
    [Column("compra_cliente_COMPRAN_IDCompra")]
    public int CompraClienteCompranIdcompra { get; set; }

    [ForeignKey("VentaIdventa")]
    [InverseProperty("VentaHasCompras")]
    public virtual Ventum VentaIdventaNavigation { get; set; } = null!;
}
