using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace SistemaBiblioteca.Presentacion.Formularios
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            ConfigurarEstiloGuna();

            // Datos iniciales para el Dashboard
            ActualizarDashboard(24, 2, 6, 5.00);
        }

        #region Configuración Visual

        private void ConfigurarEstiloGuna()
        {
            // Configuración de comportamiento de botones como RadioButtons
            ConfigurarBotonSidebar(btnInicio);
            ConfigurarBotonSidebar(btnUsuarios);
            ConfigurarBotonSidebar(btnLibros);
            ConfigurarBotonSidebar(btnPrestamos);
            ConfigurarBotonSidebar(btnReservas);
            ConfigurarBotonSidebar(btnMultas);

            // Estado del Sistema
            lblStatus.Text = "SISTEMA ONLINE";
            lblStatus.FillColor = ColorTranslator.FromHtml("#27AE60"); // Verde Esmeralda
            lblStatus.ForeColor = Color.White;
            lblStatus.Enabled = false;

            // Seleccionar Inicio por defecto
            btnInicio.Checked = true;
        }

        private void ConfigurarBotonSidebar(Guna2Button btn)
        {
            btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton; // Efecto de selección única
            btn.CheckedState.FillColor = ColorTranslator.FromHtml("#3498DB"); // Azul Primario
            btn.CheckedState.ForeColor = Color.White;
            btn.FillColor = Color.Transparent;
            btn.ForeColor = Color.White;
            btn.TextAlign = HorizontalAlignment.Left;
            btn.HoverState.FillColor = ColorTranslator.FromHtml("#34495E"); // Azul oscuro suave
        }

        public void ActualizarDashboard(int libros, int prestamos, int usuarios, double multas)
        {
            // Actualiza los indicadores del panel principal
            lblCantLibros.Text = libros.ToString();
            lblCantPrestamos.Text = prestamos.ToString();
            lblCantUsuarios.Text = usuarios.ToString();
            lblMontoMultas.Text = $"${multas:N2}";
        }

        #endregion

        #region Navegación Interna

        // Método genérico para abrir formularios dentro del panel central (guna2Panel3)
        private void AbrirFormularioContenedor<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = guna2Panel3.Controls.OfType<MiForm>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;

                guna2Panel3.Controls.Add(formulario);
                guna2Panel3.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        #endregion

        #region Eventos de Botones

        private void btnInicio_Click(object sender, EventArgs e)
        {
            // Regresa a la vista de estadísticas (Dashboard)
            foreach (Control c in guna2Panel3.Controls)
            {
                if (c is Form) c.SendToBack();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioContenedor<FrmUsuarios>(); //
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            AbrirFormularioContenedor<FrmLibros>(); //
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            AbrirFormularioContenedor<FrmPrestamos>(); //
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            AbrirFormularioContenedor<FrmReservas>(); //
        }

        private void btnMultas_Click(object sender, EventArgs e)
        {
            AbrirFormularioContenedor<FrmMultas>(); //
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Lógica de cierre de sesión
            DialogResult result = MessageBox.Show("¿Desea cerrar la sesión actual?", "Cerrar Sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                FrmLogin login = new FrmLogin();
                login.Show();
                login.FormClosed += (s, args) => Application.Exit();
            }
        }

        #endregion
    }
}