using pjGestionEmpleados.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pjGestionEmpleados.Datos
{
    public class D_Empleados
    {
        public DataTable Listar_Empleados(string cBusqueda)
        {

            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_EMPLEADOS", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@cBusqueda", SqlDbType.VarChar).Value = cBusqueda;
                sqlCon.Open();

                resultado = comando.ExecuteReader();
                tabla.Load(resultado);

                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
        }
        public string Guardar_Empleado(E_Empleado empleado)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_EMPLEADO", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@cNombre", SqlDbType.VarChar).Value = empleado.Nombre_empleado;
                comando.Parameters.Add("@cDireccion", SqlDbType.VarChar).Value = empleado.Direccion_empleado;
                comando.Parameters.Add("@dFechaNacimiento", SqlDbType.Date).Value = empleado.Fecha_nac_empleado;
                comando.Parameters.Add("@cTelefono", SqlDbType.VarChar).Value = empleado.Telefono_empleado;
                comando.Parameters.Add("@nSalario", SqlDbType.Money).Value = empleado.Salario_empleado;
                comando.Parameters.Add("@nIdDepartamento", SqlDbType.Int).Value = empleado.Id_departamento;
                comando.Parameters.Add("@nIdCargo", SqlDbType.Int).Value = empleado.Id_cargo;

                sqlCon.Open();

                respuesta = comando.ExecuteNonQuery() >= 1 ? "Ok" : "Los datos no se pudieron registrar";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return respuesta;
        }
        public string Actualizar_Empleado(E_Empleado empleado)
        {
            string resultado = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SP_ACTUALIZAR_EMPLEADO", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@nIdEmpleado", SqlDbType.Int).Value = empleado.Id_empleado;
                comando.Parameters.Add("@cNombre", SqlDbType.VarChar).Value = empleado.Nombre_empleado;
                comando.Parameters.Add("@cDireccion", SqlDbType.VarChar).Value = empleado.Direccion_empleado;
                comando.Parameters.Add("@dFechaNacimiento", SqlDbType.Date).Value = empleado.Fecha_nac_empleado;
                comando.Parameters.Add("@cTelefono", SqlDbType.VarChar).Value = empleado.Telefono_empleado;
                comando.Parameters.Add("@nSalario", SqlDbType.Money).Value = empleado.Salario_empleado;
                comando.Parameters.Add("@nIdDepartamento", SqlDbType.Int).Value = empleado.Id_departamento;
                comando.Parameters.Add("@nIdCargo", SqlDbType.Int).Value = empleado.Id_cargo;

                sqlCon.Open();

                resultado = comando.ExecuteNonQuery() <= 1 ? "Ok" : "Los datos no se pueden registrar";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return resultado;
        }
        public string Desactivar_Empleado(int iCodigoEmpleado)
        {
            string resultado = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SP_DESACTIVAR_EMPLEADO", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@nIdEmpleado", SqlDbType.Int).Value = iCodigoEmpleado;                

                sqlCon.Open();

                resultado = comando.ExecuteNonQuery() <= 1 ? "Ok" : "Los datos no se pueden registrar";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return resultado;
        }
    }
}
