using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Intermodular_Gestion.Backend.Modelo;

[Table("roles")]
public partial class Roles
{
    [Key]
    [Column("idRoles")]
    public int IdRoles { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }
}
