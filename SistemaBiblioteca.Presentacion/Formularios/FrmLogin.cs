using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaBiblioteca.Presentacion.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Obtenemos los valores de los TextBox
            string user = TextBoxUsuario.Text.Trim();
            string pass = TextBoxContraseña.Text.Trim();

            // Validación de credenciales 
            if ((user == "admin" && pass == "admin") || (user == "biblio" && pass == "biblio"))
            {
                // Login Exitoso
                this.Hide(); // Ocultamos el login

                FrmPrincipal principal = new FrmPrincipal();
                principal.Show();

                // Si se cierra el principal, se cierra la aplicación completa
                principal.FormClosed += (s, args) => Application.Exit();
            }
            else
            {
                // Error de credenciales
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Acceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

                TextBoxContraseña.Clear();
                TextBoxUsuario.Focus();
            }
        }
    }
}