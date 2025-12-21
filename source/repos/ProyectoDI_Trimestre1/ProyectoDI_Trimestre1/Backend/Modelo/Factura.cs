using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[PrimaryKey("Idfactura", "CompraIdcompra", "CompraProductoIdProducto", "CompraClienteDni", "CompraClienteCompranIdcompra")]
[Table("factura")]
[Index("CompraIdcompra", "CompraProductoIdProducto", "CompraClienteDni", "CompraClienteCompranIdcompra", Name = "fk_factura_compra1")]
public partial class Factura
{
    [Key]
    [Column("IDFactura")]
    public int Idfactura { get; set; }

    [Column("precio_compra")]
    [Precision(10, 0)]
    public decimal? PrecioCompra { get; set; }

    [Column("IVA")]
    public double? Iva { get; set; }

    [Column("FECHA", TypeName = "date")]
    public DateTime? Fecha { get; set; }

    [Column("facturacol")]
    [StringLength(100)]
    public string? Facturacol { get; set; }

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
}
