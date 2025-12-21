using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[Table("usuarios")]
public partial class Usuario
{
    [Key]
    [Column("IDUsuario")]
    public int Idusuario { get; set; }

    [Column("nom_usuario")]
    [StringLength(17)]
    public string NomUsuario { get; set; } = null!;

    [Column("contraseña_usuario")]
    [StringLength(60)]
    public string ContraseñaUsuario { get; set; } = null!;

    [InverseProperty("UsuariosIdusuarioNavigation")]
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    [InverseProperty("UsuariosIdusuarioNavigation")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
