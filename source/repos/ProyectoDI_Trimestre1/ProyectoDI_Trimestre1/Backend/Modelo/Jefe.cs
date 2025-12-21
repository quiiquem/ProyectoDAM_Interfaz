using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDI_Trimestre1.Backend.Modelo;

[Table("jefe")]
[Index("EmpleadosIdEmpleado", Name = "fk_jefe_empleados1_idx")]
public partial class Jefe
{
    [Key]
    [Column("empleados_ID_Empleado")]
    public int EmpleadosIdEmpleado { get; set; }

    [InverseProperty("JefeEmpleadosIdEmpleadoNavigation")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
