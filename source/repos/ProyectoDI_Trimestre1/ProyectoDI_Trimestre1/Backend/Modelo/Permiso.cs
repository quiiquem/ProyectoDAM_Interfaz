using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[Table("permisos")]
public partial class Permiso
{
    [Key]
    [Column("idpermisos")]
    public int Idpermisos { get; set; }

    [Column("descripcionpermiso")]
    [StringLength(400)]
    public string? Descripcionpermiso { get; set; }

    [ForeignKey("PermisosIdpermisos")]
    [InverseProperty("PermisosIdpermisos")]
    public virtual ICollection<Role> RolesIdroles { get; set; } = new List<Role>();
}
