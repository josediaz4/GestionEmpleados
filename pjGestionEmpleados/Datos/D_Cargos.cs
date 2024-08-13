using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pjGestionEmpleados.Datos
{
    public class D_Cargos
    {
        public DataTable Listar_Cargos()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_CARGOS", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

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
    }
}
