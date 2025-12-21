using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[Table("categorias")]
[Index("Idcategorias", Name = "idcategorias_UNIQUE", IsUnique = true)]
public partial class Categoria
{
    [Key]
    [Column("idcategorias")]
    public int Idcategorias { get; set; }

    [Column("descripcion")]
    [StringLength(400)]
    public string? Descripcion { get; set; }

    [InverseProperty("CategoriasIdcategoriasNavigation")]
    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
