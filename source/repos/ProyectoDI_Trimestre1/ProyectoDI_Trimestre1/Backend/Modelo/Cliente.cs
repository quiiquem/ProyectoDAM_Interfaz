using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Intermodular_Gestion.Backend.Modelo;

[Table("cliente")]
[Index("UsuariosIdusuario", Name = "fk_cliente_USUARIOS1_idx")]
public partial class Cliente
{
    [Key]
    [Column("USUARIOS_IDUsuario")]
    public int UsuariosIdusuario { get; set; }

    [StringLength(45)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    public string Apellido1 { get; set; } = null!;

    [StringLength(80)]
    public string Dirección { get; set; } = null!;

    [StringLength(50)]
    public string? Apellido2 { get; set; }

    [StringLength(80)]
    public string Pais { get; set; } = null!;

    [StringLength(100)]
    public string Ciudad { get; set; } = null!;

    public int CodPostal { get; set; }

    public int Telefono { get; set; }

    [StringLength(50)]
    public string? Provincia { get; set; }

    [InverseProperty("ClienteUsuariosIdusuarioNavigation")]
    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    [ForeignKey("UsuariosIdusuario")]
    [InverseProperty("Cliente")]
    public virtual Usuario UsuariosIdusuarioNavigation { get; set; } = null!;
}
