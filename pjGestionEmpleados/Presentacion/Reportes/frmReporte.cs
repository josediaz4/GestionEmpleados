using System;
using System.Windows.Forms;

namespace pjGestionEmpleados.Presentacion.Reportes
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet.SP_LISTAR_EMPLEADOS' Puede moverla o quitarla según sea necesario.
            this.sP_LISTAR_EMPLEADOSTableAdapter.Fill(this.dataSet.SP_LISTAR_EMPLEADOS, cBusqueda: txtFiltrar.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
