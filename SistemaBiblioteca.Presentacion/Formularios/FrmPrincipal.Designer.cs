namespace SistemaBiblioteca.Presentacion.Formularios
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges edges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnSalir = new Guna.UI2.WinForms.Guna2Button();
            btnMultas = new Guna.UI2.WinForms.Guna2Button();
            btnReservas = new Guna.UI2.WinForms.Guna2Button();
            btnPrestamos = new Guna.UI2.WinForms.Guna2Button();
            btnLibros = new Guna.UI2.WinForms.Guna2Button();
            btnUsuarios = new Guna.UI2.WinForms.Guna2Button();
            btnInicio = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            lblStatus = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            lblMontoMultas = new Label();
            lblCantUsuarios = new Label();
            lblCantPrestamos = new Label();
            lblCantLibros = new Label();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            guna2Panel3.SuspendLayout();
            SuspendLayout();

            // --- SIDEBAR (Panel Lateral Izquierdo) ---
            guna2Panel1.Controls.Add(guna2HtmlLabel1);
            guna2Panel1.Controls.Add(btnSalir);
            guna2Panel1.Controls.Add(btnMultas);
            guna2Panel1.Controls.Add(btnReservas);
            guna2Panel1.Controls.Add(btnPrestamos);
            guna2Panel1.Controls.Add(btnLibros);
            guna2Panel1.Controls.Add(btnUsuarios);
            guna2Panel1.Controls.Add(btnInicio);
            guna2Panel1.Dock = DockStyle.Left;
            guna2Panel1.FillColor = Color.FromArgb(44, 62, 80); // #2C3E50
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Size = new Size(200, 500);
            guna2Panel1.TabIndex = 0;

            // Logotipo o Título del Sidebar
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            guna2HtmlLabel1.ForeColor = Color.White;
            guna2HtmlLabel1.Location = new Point(50, 30);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(95, 23);
            guna2HtmlLabel1.Text = "BIBLIOTECA";

            // Botón Inicio
            btnInicio.Location = new Point(10, 100);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(180, 45);
            btnInicio.Text = "Inicio";
            btnInicio.Click += btnInicio_Click; // Conecta el evento

            // Botón Usuarios
            btnUsuarios.Location = new Point(10, 150);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(180, 45);
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.Click += btnUsuarios_Click;

            // Botón Libros
            btnLibros.Location = new Point(10, 200);
            btnLibros.Name = "btnLibros";
            btnLibros.Size = new Size(180, 45);
            btnLibros.Text = "Libros";
            btnLibros.Click += btnLibros_Click;

            // Botón Préstamos
            btnPrestamos.Location = new Point(10, 250);
            btnPrestamos.Name = "btnPrestamos";
            btnPrestamos.Size = new Size(180, 45);
            btnPrestamos.Text = "Préstamos";
            btnPrestamos.Click += btnPrestamos_Click;

            // Botón Reservas
            btnReservas.Location = new Point(10, 300);
            btnReservas.Name = "btnReservas";
            btnReservas.Size = new Size(180, 45);
            btnReservas.Text = "Reservas";
            btnReservas.Click += btnReservas_Click;

            // Botón Multas
            btnMultas.Location = new Point(10, 350);
            btnMultas.Name = "btnMultas";
            btnMultas.Size = new Size(180, 45);
            btnMultas.Text = "Multas";
            btnMultas.Click += btnMultas_Click;

            // Botón Salir
            btnSalir.Location = new Point(10, 450);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(180, 35);
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click; // Conecta el evento de cierre de sesión

            // --- HEADER (Panel Superior) ---
            guna2Panel2.Controls.Add(lblStatus);
            guna2Panel2.Dock = DockStyle.Top;
            guna2Panel2.FillColor = Color.FromArgb(44, 62, 80);
            guna2Panel2.Location = new Point(200, 0);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.Size = new Size(700, 80);
            guna2Panel2.TabIndex = 1;

            lblStatus.Location = new Point(500, 25);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(150, 30);
            lblStatus.BorderRadius = 15;

            // --- CONTENIDO (Panel Blanco / Dashboard) ---
            guna2Panel3.Controls.Add(lblMontoMultas);
            guna2Panel3.Controls.Add(lblCantUsuarios);
            guna2Panel3.Controls.Add(lblCantPrestamos);
            guna2Panel3.Controls.Add(lblCantLibros);
            guna2Panel3.Dock = DockStyle.Fill;
            guna2Panel3.FillColor = Color.White;
            guna2Panel3.Location = new Point(200, 80);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.Size = new Size(700, 420);
            guna2Panel3.TabIndex = 2;

            // Configuración de etiquetas de estadísticas
            lblCantLibros.Location = new Point(50, 50); lblCantLibros.Font = new Font("Segoe UI", 24, FontStyle.Bold); lblCantLibros.AutoSize = true; lblCantLibros.Name = "lblCantLibros";
            lblCantPrestamos.Location = new Point(200, 50); lblCantPrestamos.Font = new Font("Segoe UI", 24, FontStyle.Bold); lblCantPrestamos.AutoSize = true; lblCantPrestamos.Name = "lblCantPrestamos";
            lblCantUsuarios.Location = new Point(350, 50); lblCantUsuarios.Font = new Font("Segoe UI", 24, FontStyle.Bold); lblCantUsuarios.AutoSize = true; lblCantUsuarios.Name = "lblCantUsuarios";
            lblMontoMultas.Location = new Point(500, 50); lblMontoMultas.Font = new Font("Segoe UI", 24, FontStyle.Bold); lblMontoMultas.AutoSize = true; lblMontoMultas.Name = "lblMontoMultas";

            // --- PROPIEDADES DEL FORMULARIO PRINCIPAL ---
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 500);
            Controls.Add(guna2Panel3);
            Controls.Add(guna2Panel2);
            Controls.Add(guna2Panel1);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Operativo Bibliotecario";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            guna2Panel3.ResumeLayout(false);
            guna2Panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Button btnInicio;
        private Guna.UI2.WinForms.Guna2Button btnUsuarios;
        private Guna.UI2.WinForms.Guna2Button btnLibros;
        private Guna.UI2.WinForms.Guna2Button btnPrestamos;
        private Guna.UI2.WinForms.Guna2Button btnReservas;
        private Guna.UI2.WinForms.Guna2Button btnMultas;
        private Guna.UI2.WinForms.Guna2Button btnSalir;
        private Guna.UI2.WinForms.Guna2Button lblStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Label lblCantLibros;
        private Label lblCantPrestamos;
        private Label lblCantUsuarios;
        private Label lblMontoMultas;
    }
}