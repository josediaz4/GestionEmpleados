using pjGestionEmpleados.Datos;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pjGestionEmpleados.Presentacion
{
    public partial class frmConectar : Form
    {
        public frmConectar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();

            sqlCon = Conexion.crearInstancia().CrearConexion();

            try
            {
                sqlCon.Open();
                MessageBox.Show("Se conectó correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
