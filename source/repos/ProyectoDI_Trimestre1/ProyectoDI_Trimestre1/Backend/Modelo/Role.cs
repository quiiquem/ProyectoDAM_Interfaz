using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[Table("roles")]
[Index("UsuariosIdusuario", Name = "fk_roles_USUARIOS1_idx")]
public partial class Role
{
    [Key]
    [Column("idroles")]
    public int Idroles { get; set; }

    [Column("nombrerol")]
    [StringLength(30)]
    public string Nombrerol { get; set; } = null!;

    [Column("descrol")]
    [StringLength(400)]
    public string? Descrol { get; set; }

    [Column("USUARIOS_IDUsuario")]
    public int UsuariosIdusuario { get; set; }

    [ForeignKey("UsuariosIdusuario")]
    [InverseProperty("Roles")]
    public virtual Usuario UsuariosIdusuarioNavigation { get; set; } = null!;

    [ForeignKey("RolesIdroles")]
    [InverseProperty("RolesIdroles")]
    public virtual ICollection<Permiso> PermisosIdpermisos { get; set; } = new List<Permiso>();
}
