using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[Table("venta")]
public partial class Ventum
{
    [Key]
    [Column("idventa")]
    public int Idventa { get; set; }

    [InverseProperty("VentaIdventaNavigation")]
    public virtual ICollection<VentaHasCompra> VentaHasCompras { get; set; } = new List<VentaHasCompra>();

    [ForeignKey("VentaIdventa")]
    [InverseProperty("VentaIdventa")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
