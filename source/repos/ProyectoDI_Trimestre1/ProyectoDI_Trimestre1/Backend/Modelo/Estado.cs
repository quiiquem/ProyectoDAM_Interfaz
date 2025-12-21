using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[Table("estado")]
public partial class Estado
{
    [Key]
    [Column("idestado")]
    public int Idestado { get; set; }

    [Column("descripcion")]
    [StringLength(400)]
    public string? Descripcion { get; set; }

    [InverseProperty("EstadoIdestadoNavigation")]
    public virtual ICollection<EstadoHasProducto> EstadoHasProductos { get; set; } = new List<EstadoHasProducto>();
}
