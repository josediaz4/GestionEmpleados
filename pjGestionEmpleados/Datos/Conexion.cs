using System;
using System.Data.SqlClient;

namespace pjGestionEmpleados.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private static Conexion Con = null;

        public Conexion()
        {
            Base = "db_gestion_empleados";
            Servidor = "DESKTOP-MKDIP02\\SQLEXPRESS";
            Usuario = "m@nu";
            Clave = "Manudiaz1";
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection cadena = new SqlConnection();

            try
            {
                cadena.ConnectionString = "Server=" + Servidor + ";Database=" + Base + "; User Id="+Usuario+"; Password="+Clave;
            }
            catch (Exception ex)
            {
                cadena = null;
                throw ex;
            }

            return cadena;
        }

        public static Conexion crearInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }

            return Con;
        }


    }
}
