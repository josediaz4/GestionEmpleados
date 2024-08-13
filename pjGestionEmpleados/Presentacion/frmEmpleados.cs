using pjGestionEmpleados.Datos;
using pjGestionEmpleados.Entidades;
using pjGestionEmpleados.Presentacion.Reportes;
using System;
using System.Windows.Forms;

namespace pjGestionEmpleados.Presentacion
{
    public partial class frmEmpleados : Form
    {
        #region Variables
        int iCodigoEmpleado = 0;
        bool bEstadoGuardar = true;

        #endregion
        public frmEmpleados()
        {
            InitializeComponent();
        }

        #region Métodos
        private void CargarEmpleados(string cBusqueda)
        {
            D_Empleados datos = new D_Empleados();
            dgvGrillar.DataSource = datos.Listar_Empleados(cBusqueda);

            FormatoListaEmpleados();
        }
        private void FormatoListaEmpleados()
        {
            dgvGrillar.Columns[0].Width = 50;
            dgvGrillar.Columns[1].Width = 160;
            dgvGrillar.Columns[2].Width = 160;
            dgvGrillar.Columns[5].Width = 200;
            dgvGrillar.Columns[7].Width = 100;

        }
        private void CargarDepartamentos()
        {
            D_Departamentos datos = new D_Departamentos();
            cmbDepartamento.DataSource = datos.Listar_Departamentos();
            cmbDepartamento.ValueMember = "Id_departamento";
            cmbDepartamento.DisplayMember = "Nombre_departamento";
            cmbDepartamento.SelectedIndex = -1;
        }
        private void CargarCargos()
        {
            D_Cargos datos = new D_Cargos();
            cmbCargo.DataSource = datos.Listar_Cargos();
            cmbCargo.ValueMember = "Id_cargo";
            cmbCargo.DisplayMember = "Nombre_cargo";
            cmbCargo.SelectedIndex = -1;
        }
        private void ActivarTextos(bool bEstado)
        {
            txtNombre.Enabled = bEstado;
            txtDireccion.Enabled = bEstado;
            txtSalario.Enabled = bEstado;
            txtTelefono.Enabled = bEstado;
            cmbDepartamento.Enabled = bEstado;
            cmbCargo.Enabled = bEstado;
            dtpFechaNacimiento.Enabled = bEstado;

            txtBuscar.Enabled = !bEstado;
        }
        private void ActivarBotones(bool bEstado)
        {
            btnNuevo.Enabled = bEstado;
            btnActualizar.Enabled = bEstado;
            btnEliminar.Enabled = bEstado;
            btnReporte.Enabled = bEstado;

            btnGuardar.Visible = !bEstado;
            btnCancelar.Visible = !bEstado;
        }
        private void SeleccionarEmpleado()
        {
            iCodigoEmpleado = Convert.ToInt32(dgvGrillar.CurrentRow.Cells["Id"].Value);

            txtNombre.Text = Convert.ToString(dgvGrillar.CurrentRow.Cells["Nombre"].Value);
            txtDireccion.Text = Convert.ToString(dgvGrillar.CurrentRow.Cells["Dirección"].Value);
            txtSalario.Text = Convert.ToString(dgvGrillar.CurrentRow.Cells["Salario"].Value);
            txtTelefono.Text = Convert.ToString(dgvGrillar.CurrentRow.Cells["Teléfono"].Value);
            cmbDepartamento.Text = Convert.ToString(dgvGrillar.CurrentRow.Cells["Departamento"].Value);
            cmbCargo.Text = Convert.ToString(dgvGrillar.CurrentRow.Cells["Cargo"].Value);
            dtpFechaNacimiento.Value = Convert.ToDateTime(dgvGrillar.CurrentRow.Cells["Fecha Nacimiento"].Value);
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtSalario.Clear();
            txtTelefono.Clear();
            txtBuscar.Clear();

            cmbDepartamento.SelectedIndex = -1;
            cmbCargo.SelectedIndex = -1;

            dtpFechaNacimiento.Value = DateTime.Now;
            iCodigoEmpleado = 0;

        }
        private void GuardarEmpleado()
        {
            E_Empleado empleado = new E_Empleado
            {
                Nombre_empleado = txtNombre.Text,
                Direccion_empleado = txtDireccion.Text,
                Telefono_empleado = txtTelefono.Text,
                Salario_empleado = Convert.ToDecimal(txtSalario.Text),
                Fecha_nac_empleado = dtpFechaNacimiento.Value,
                Id_departamento = Convert.ToInt32(cmbDepartamento.SelectedValue),
                Id_cargo = Convert.ToInt32(cmbCargo.SelectedValue)
            };

            D_Empleados datos = new D_Empleados();
            string respuesta = datos.Guardar_Empleado(empleado);

            if (respuesta == "Ok")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Datos Guardados Correctamente", "Sistema de Gestión de Empelados",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(respuesta, "Sistema de Gestión de Empleados",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void ActualizarEmpleado()
        {
            E_Empleado empleado = new E_Empleado
            {
                Id_empleado = iCodigoEmpleado,
                Nombre_empleado = txtNombre.Text,
                Direccion_empleado = txtDireccion.Text,
                Telefono_empleado = txtTelefono.Text,
                Salario_empleado = Convert.ToDecimal(txtSalario.Text),
                Fecha_nac_empleado = dtpFechaNacimiento.Value,
                Id_departamento = Convert.ToInt32(cmbDepartamento.SelectedValue),
                Id_cargo = Convert.ToInt32(cmbCargo.SelectedValue)
            };

            D_Empleados datos = new D_Empleados();
            string respuesta = datos.Actualizar_Empleado(empleado);

            if (respuesta == "Ok")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Datos Actualizados Correctamente", "Sistema de Gestión de Empleados",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(respuesta, "Sistema de Gestión de Empleados",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DesactivarEmpleado(int iCodigoEmpleado)
        {
            D_Empleados datos = new D_Empleados();
            string respuesta = datos.Desactivar_Empleado(iCodigoEmpleado);

            if (respuesta == "Ok")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Registro Eliminado Correctamente", "Sistema de Gestión de Empleados",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(respuesta, "Sistema de Gestión de Empleados",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool ValidarTextos()
        {
            bool hayTextosVacios = false;

            if (string.IsNullOrEmpty(txtNombre.Text)) hayTextosVacios = true;
            if (string.IsNullOrEmpty(txtTelefono.Text)) hayTextosVacios = true;
            if (string.IsNullOrEmpty(txtSalario.Text)) hayTextosVacios = true;

            return hayTextosVacios;
        }
        #endregion

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados("%");
            CargarDepartamentos();
            CargarCargos();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarEmpleados(txtBuscar.Text);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarEmpleados(txtBuscar.Text);
        }
        private void dgvGrillar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarEmpleado();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bEstadoGuardar = true;
            iCodigoEmpleado = 0;

            ActivarTextos(true);
            ActivarBotones(false);
            Limpiar();

            txtNombre.Select();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (iCodigoEmpleado == 0)
            {
                MessageBox.Show("Seleccione un Registro", "Sistema de Gestión de Empleados"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bEstadoGuardar = false;

                ActivarTextos(true);
                ActivarBotones(false);

                txtNombre.Select();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (iCodigoEmpleado == 0)
            {
                MessageBox.Show("Seleccione un Registro", "Sistema de Gestión de Empleados"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Está seguro de eliminar este registro?", "Sistema de Gestión de Empleados",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    DesactivarEmpleado(iCodigoEmpleado);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarTextos())
            {
                MessageBox.Show("Los campos con * son obligatorios", "Sistema de Gestión de Empleados",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (bEstadoGuardar)
                {
                    GuardarEmpleado();
                }
                else
                {
                    ActualizarEmpleado();
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bEstadoGuardar = true;
            iCodigoEmpleado = 0;

            ActivarTextos(false);
            ActivarBotones(true);

            Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmReporte frmReporte = new frmReporte();
            frmReporte.txtFiltrar.Text = txtBuscar.Text;

            frmReporte.ShowDialog();
        }
    }
}
