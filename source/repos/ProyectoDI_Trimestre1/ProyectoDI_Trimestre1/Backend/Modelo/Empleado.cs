using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[PrimaryKey("IdEmpleado", "JefeIdJefe", "JefeEmpleadosIdEmpleado", "CompraIdcompra", "CompraProductoIdProducto", "CompraClienteDni", "CompraClienteCompranIdcompra")]
[Table("empleados")]
[Index("Usuario", Name = "Usuario_UNIQUE", IsUnique = true)]
[Index("CompraIdcompra", "CompraProductoIdProducto", "CompraClienteDni", "CompraClienteCompranIdcompra", Name = "fk_empleados_compra1_idx")]
[Index("JefeEmpleadosIdEmpleado", Name = "fk_empleados_jefe1")]
[Index("JefeIdJefe", "JefeEmpleadosIdEmpleado", Name = "fk_empleados_jefe1_idx")]
[Index("JefeIdJefe", Name = "jefe_idJEFE_UNIQUE", IsUnique = true)]
public partial class Empleado
{
    [Key]
    [Column("ID_Empleado")]
    public int IdEmpleado { get; set; }

    [StringLength(30)]
    public string? Nombre { get; set; }

    [StringLength(90)]
    public string? Apellidos { get; set; }

    [StringLength(60)]
    public string? Usuario { get; set; }

    [StringLength(60)]
    public string? Contraseña { get; set; }

    [Key]
    [Column("jefe_idJEFE")]
    public int JefeIdJefe { get; set; }

    [Key]
    [Column("jefe_empleados_ID_Empleado")]
    public int JefeEmpleadosIdEmpleado { get; set; }

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

    [ForeignKey("JefeEmpleadosIdEmpleado")]
    [InverseProperty("Empleados")]
    public virtual Jefe JefeEmpleadosIdEmpleadoNavigation { get; set; } = null!;
}
