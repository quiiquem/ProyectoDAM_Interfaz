using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Intermodular_Gestion.Backend.Modelo;

[Table("usuario")]
[Index("Email", Name = "email_UNIQUE", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("IDUsuario")]
    public int Idusuario { get; set; }

    [Column("nom_usuario")]
    [StringLength(17)]
    public string NomUsuario { get; set; } = null!;

    [Column("contrasenya_usuario")]
    [StringLength(60)]
    public string Contrasenya_Usuario { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [InverseProperty("UsuariosIdusuarioNavigation")]
    public virtual Cliente? Cliente { get; set; }

    [InverseProperty("UsuariosIdusuarioNavigation")]
    public virtual ICollection<Roles> Roleses { get; set; } = new List<Roles>();
}
