using System;

namespace pjGestionEmpleados.Entidades
{
    public class E_Empleado
    {
        public int Id_empleado { get; set; }
        public string Nombre_empleado { get; set; }
        public string Direccion_empleado { get; set; }
        public string Telefono_empleado { get; set; }
        public decimal Salario_empleado { get; set; }
        public DateTime Fecha_nac_empleado { get; set; }
        public int? Id_departamento { get; set; }
        public int? Id_cargo { get; set; }
    }
}
