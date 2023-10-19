using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENEform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // En el evento de inicio de sesión
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;

            // Realiza la autenticación en la base de datos y obtén el rol del usuario.
            string rol = ObtenerRolDesdeBaseDeDatos(nombreUsuario, contraseña);

            if (rol == "usuario")
            {
                // El usuario es un usuario normal.
                FormUsuario formUsuario = new FormUsuario();
                formUsuario.Show();
            }
            else if (rol == "administrador")
            {
                // El usuario es un administrador.
                FormAdministrador formAdmin = new FormAdministrador();
                formAdministrador.ActiveForm.Show();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        private string ObtenerRolDesdeBaseDeDatos(string nombreUsuario, string contraseña)
        {
            // Realiza una consulta a la base de datos para obtener el rol del usuario.
            // Esto es solo un ejemplo simplificado; en la práctica, necesitarás una lógica más sólida.
            // Aquí, se retorna "usuario" o "administrador" solo como ejemplo.
            return (nombreUsuario == "usuario1" && contraseña == "contraseña1") ? "usuario" :
                   (nombreUsuario == "admin" && contraseña == "adminpass") ? "administrador" : "";
        }

    }
}
