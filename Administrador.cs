using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENEform
{
    public partial class formAdministrador : Form
    {
        public formAdministrador()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0GIDJ12; Initial Catalog=ENE; Integrated Security=True");
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string insertQuery = "INSERT INTO Administrador (RutEmpleado, Nombres, Apellidos, Direccion, Telefono, ValorHora, ValorExtra) " +
                                     "VALUES (@RutEmpleado, @Nombres, @Apellidos, @Direccion, @Telefono, @ValorHora, @ValorExtra)";

                using (SqlCommand command = new SqlCommand(insertQuery, conn))
                {
                    command.Parameters.AddWithValue("@RutEmpleado", txtRutEmpleado.Text);
                    command.Parameters.AddWithValue("@Nombres", txtNombre.Text);
                    command.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                    command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    command.Parameters.AddWithValue("@ValorHora", Convert.ToDecimal(txtValorHora.Text));
                    command.Parameters.AddWithValue("@ValorExtra", Convert.ToDecimal(txtValorExtra.Text));

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Datos guardados con éxito.");

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Cuando se hace clic en el botón "btnActualizar", actualiza la vista de datos
            ActualizarVista();
        }
        private void LimpiarCampos()
        {
            // Limpia todos los TextBox
            txtRutEmpleado.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtValorHora.Clear();
            txtValorExtra.Clear();

            // Deshabilita los TextBox
            HabilitarTextBox(false);
        }
        private void ActualizarVista()
        {
            try
            {
                conn.Open();
                // Realiza la consulta SQL para obtener los datos actualizados
                string selectQuery = "SELECT RutEmpleado, Nombres, Apellidos, Direccion, Telefono, ValorHora, ValorExtra FROM Administrador";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la vista: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Habilita todos los TextBox para permitir la entrada de nuevos datos
            HabilitarTextBox(true);
        }
        private void HabilitarTextBox(bool habilitar)
        {
            // Habilita o deshabilita todos los TextBox
            txtRutEmpleado.Enabled = habilitar;
            txtNombre.Enabled = habilitar;
            txtApellidos.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtValorHora.Enabled = habilitar;
            txtValorExtra.Enabled = habilitar;
        }
        private void Administrador_Load(object sender, EventArgs e)
        {
            HabilitarTextBox(false);
            // Inicialmente, carga la vista de datos
            ActualizarVista();
        }
    }
}
