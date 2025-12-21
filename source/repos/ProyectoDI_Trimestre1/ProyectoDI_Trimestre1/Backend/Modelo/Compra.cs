using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[PrimaryKey("Idcompra", "ProductoIdProducto", "ClienteDni", "CategoriasIdcategorias")]
[Table("compra")]
[Index("ProductoIdProducto", Name = "fk_COMPRAN_PRODUCTO1_idx")]
[Index("CategoriasIdcategorias", Name = "fk_compra_categorias1_idx")]
[Index("ClienteDni", Name = "fk_compran_cliente1_idx")]
public partial class Compra
{
    [Key]
    [Column("IDCompra")]
    public int Idcompra { get; set; }

    [Key]
    [Column("PRODUCTO_ID_Producto")]
    public int ProductoIdProducto { get; set; }

    [Key]
    [Column("cliente_DNI")]
    [StringLength(9)]
    public string ClienteDni { get; set; } = null!;

    [Key]
    [Column("categorias_idcategorias")]
    public int CategoriasIdcategorias { get; set; }

    [ForeignKey("CategoriasIdcategorias")]
    [InverseProperty("Compras")]
    public virtual Categoria CategoriasIdcategoriasNavigation { get; set; } = null!;
}
