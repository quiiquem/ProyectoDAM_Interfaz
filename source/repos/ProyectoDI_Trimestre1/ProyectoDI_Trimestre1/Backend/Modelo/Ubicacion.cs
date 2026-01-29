using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Intermodular_Gestion.Backend.Modelo;

[Table("ubicacion")]
public partial class Ubicacion
{
    [Key]
    [Column("idUbicacion")]
    public int IdUbicacion { get; set; }

    [StringLength(400)]
    public string? Descripcion { get; set; }

    [InverseProperty("UbicacionIdUbicacionNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
