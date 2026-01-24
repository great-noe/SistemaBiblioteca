using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace SistemaBiblioteca.Presentacion.Formularios
{
    public partial class FrmPrincipal : Form
    {
        // Colores del Dashboard (Basados en tu imagen)
        private Color colorAzul = ColorTranslator.FromHtml("#3498DB");
        private Color colorNaranja = ColorTranslator.FromHtml("#F39C12");
        private Color colorVerde = ColorTranslator.FromHtml("#2ECC71");
        private Color colorRojo = ColorTranslator.FromHtml("#E74C3C");

        public FrmPrincipal()
        {
            InitializeComponent();
            ConfigurarEstiloGuna();

            // Al arrancar, mostramos el Dashboard por defecto
            CargarDashboardInicio();
        }

        #region Configuración Visual

        private void ConfigurarEstiloGuna()
        {
            ConfigurarBotonSidebar(btnInicio);
            ConfigurarBotonSidebar(btnUsuarios);
            ConfigurarBotonSidebar(btnLibros);
            ConfigurarBotonSidebar(btnPrestamos);
            ConfigurarBotonSidebar(btnReservas);
            ConfigurarBotonSidebar(btnMultas);

            lblStatus.Text = "SISTEMA ONLINE";
            lblStatus.FillColor = ColorTranslator.FromHtml("#27AE60");
            lblStatus.ForeColor = Color.White;
            lblStatus.Enabled = false;

            btnInicio.Checked = true;
        }

        private void ConfigurarBotonSidebar(Guna2Button btn)
        {
            btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btn.BackColor = Color.Transparent;
            btn.FillColor = Color.Transparent;
            btn.ForeColor = Color.White;

            btn.CheckedState.FillColor = Color.FromArgb(52, 152, 219);
            btn.CheckedState.ForeColor = Color.White;
            btn.HoverState.FillColor = Color.FromArgb(52, 73, 94);
        }

        // --- NUEVO MÉTODO: Dibuja las tarjetas informativas ---
        private void CargarDashboardInicio()
        {
            guna2Panel3.Controls.Clear(); // Limpia formularios abiertos
            guna2Panel3.BackColor = Color.FromArgb(243, 244, 246);

            // Título de bienvenida
            Label lblTitulo = new Label
            {
                Text = "Sistema Operativo Bibliotecario",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                Location = new Point(30, 20),
                AutoSize = true
            };
            guna2Panel3.Controls.Add(lblTitulo);

            // Tarjetas de Estadísticas
            CrearTarjetaStat("LIBROS DISPONIBLES", "7", "de 24 totales", colorAzul, 30, 100);
            CrearTarjetaStat("PRÉSTAMOS ACTIVOS", "2", "0 en curso hoy", colorNaranja, 240, 100);
            CrearTarjetaStat("USUARIOS MAESTROS", "6", "base de datos", colorVerde, 450, 100);
            CrearTarjetaStat("MULTAS PENDIENTES", "$5.00", "1 cargos", colorRojo, 660, 100);

       
        }

        private void CrearTarjetaStat(string titulo, string valor, string sub, Color colorBorder, int x, int y)
        {
            Guna2Panel card = new Guna2Panel
            {
                Size = new Size(190, 110),
                Location = new Point(x, y),
                FillColor = Color.White,
                BorderRadius = 12,
                BackColor = Color.Transparent
            };
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.BorderRadius = 12;

            Guna2Panel line = new Guna2Panel
            {
                Size = new Size(190, 5),
                Dock = DockStyle.Top,
                FillColor = colorBorder,
                BorderRadius = 12
            };

            Label lblT = new Label { Text = titulo, Font = new Font("Segoe UI", 7, FontStyle.Bold), ForeColor = Color.Gray, Location = new Point(15, 20), AutoSize = true };
            Label lblV = new Label { Text = valor, Font = new Font("Segoe UI", 20, FontStyle.Bold), ForeColor = Color.Black, Location = new Point(15, 38), AutoSize = true };
            Label lblS = new Label { Text = sub, Font = new Font("Segoe UI", 7), ForeColor = Color.Silver, Location = new Point(15, 80), AutoSize = true };

            card.Controls.Add(line);
            card.Controls.Add(lblT);
            card.Controls.Add(lblV);
            card.Controls.Add(lblS);
            guna2Panel3.Controls.Add(card);
        }

        public void ActualizarDashboard(int libros, int prestamos, int usuarios, double multas)
        {
            // Este método puedes usarlo si quieres actualizar los textos manualmente
        }

        #endregion

        #region Navegación Interna

        private void AbrirFormularioContenedor<MiForm>() where MiForm : Form, new()
        {
            guna2Panel3.Controls.Clear(); // Limpia las tarjetas para mostrar el formulario

            Form formulario = new MiForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            guna2Panel3.Controls.Add(formulario);
            guna2Panel3.Tag = formulario;
            formulario.Show();
            formulario.BringToFront();
        }

        #endregion

        #region Eventos de Botones

        private void btnInicio_Click(object sender, EventArgs e)
        {
            // AL HACER CLICK EN INICIO: Cargamos de nuevo el Dashboard con las tarjetas
            CargarDashboardInicio();
        }

        private void btnUsuarios_Click(object sender, EventArgs e) => AbrirFormularioContenedor<FrmUsuarios>();
        private void btnLibros_Click(object sender, EventArgs e) => AbrirFormularioContenedor<FrmLibros>();
        private void btnPrestamos_Click(object sender, EventArgs e) => AbrirFormularioContenedor<FrmPrestamos>();
        private void btnReservas_Click(object sender, EventArgs e) => AbrirFormularioContenedor<FrmReservas>();
        private void btnMultas_Click(object sender, EventArgs e) => AbrirFormularioContenedor<FrmMultas>();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar sesión?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new FrmLogin().Show();
            }
        }

        #endregion
    }
}