using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[PrimaryKey("Dni", "UsuariosIdusuario")]
[Table("cliente")]
[Index("Email", Name = "Email_UNIQUE", IsUnique = true)]
[Index("UsuariosIdusuario", Name = "fk_cliente_USUARIOS1_idx")]
public partial class Cliente
{
    [Key]
    [Column("DNI")]
    [StringLength(9)]
    public string Dni { get; set; } = null!;

    [StringLength(45)]
    public string Nombre { get; set; } = null!;

    [StringLength(90)]
    public string? Apellidos { get; set; }

    [StringLength(80)]
    public string? Dirección { get; set; }

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Key]
    [Column("USUARIOS_IDUsuario")]
    public int UsuariosIdusuario { get; set; }

    [ForeignKey("UsuariosIdusuario")]
    [InverseProperty("Clientes")]
    public virtual Usuario UsuariosIdusuarioNavigation { get; set; } = null!;
}
