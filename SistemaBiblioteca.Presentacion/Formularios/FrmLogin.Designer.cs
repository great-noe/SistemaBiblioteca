namespace SistemaBiblioteca.Presentacion.Formularios
{
    partial class FrmLogin
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnIniciarSesion = new Guna.UI2.WinForms.Guna2Button();
            TextBoxContraseña = new Guna.UI2.WinForms.Guna2TextBox();
            TextBoxUsuario = new Guna.UI2.WinForms.Guna2TextBox();
            txtContraseña = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtUsuario = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderRadius = 20;
            guna2Panel1.Controls.Add(btnIniciarSesion);
            guna2Panel1.Controls.Add(TextBoxContraseña);
            guna2Panel1.Controls.Add(TextBoxUsuario);
            guna2Panel1.Controls.Add(txtContraseña);
            guna2Panel1.Controls.Add(txtUsuario);
            guna2Panel1.Controls.Add(txtTitulo);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(250, 50);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.BorderRadius = 20;
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.ShadowDecoration.Enabled = true;
            guna2Panel1.Size = new Size(300, 350);
            guna2Panel1.TabIndex = 0;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BorderRadius = 10;
            btnIniciarSesion.CustomizableEdges = customizableEdges1;
            btnIniciarSesion.FillColor = Color.FromArgb(44, 62, 80);
            btnIniciarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIniciarSesion.ForeColor = Color.White;
            btnIniciarSesion.Location = new Point(40, 260);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnIniciarSesion.Size = new Size(220, 45);
            btnIniciarSesion.TabIndex = 0;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // TextBoxContraseña
            // 
            TextBoxContraseña.BorderRadius = 8;
            TextBoxContraseña.BorderThickness = 0;
            TextBoxContraseña.CustomizableEdges = customizableEdges3;
            TextBoxContraseña.DefaultText = "";
            TextBoxContraseña.FillColor = Color.FromArgb(55, 55, 55);
            TextBoxContraseña.Font = new Font("Segoe UI", 9F);
            TextBoxContraseña.ForeColor = Color.White;
            TextBoxContraseña.Location = new Point(40, 195);
            TextBoxContraseña.Name = "TextBoxContraseña";
            TextBoxContraseña.PasswordChar = '●';
            TextBoxContraseña.PlaceholderText = "admin o biblio";
            TextBoxContraseña.SelectedText = "";
            TextBoxContraseña.ShadowDecoration.CustomizableEdges = customizableEdges4;
            TextBoxContraseña.Size = new Size(220, 36);
            TextBoxContraseña.TabIndex = 1;
            // 
            // TextBoxUsuario
            // 
            TextBoxUsuario.BorderRadius = 8;
            TextBoxUsuario.BorderThickness = 0;
            TextBoxUsuario.CustomizableEdges = customizableEdges5;
            TextBoxUsuario.DefaultText = "";
            TextBoxUsuario.FillColor = Color.FromArgb(55, 55, 55);
            TextBoxUsuario.Font = new Font("Segoe UI", 9F);
            TextBoxUsuario.ForeColor = Color.White;
            TextBoxUsuario.Location = new Point(40, 120);
            TextBoxUsuario.Name = "TextBoxUsuario";
            TextBoxUsuario.PlaceholderText = "admin o biblio";
            TextBoxUsuario.SelectedText = "";
            TextBoxUsuario.ShadowDecoration.CustomizableEdges = customizableEdges6;
            TextBoxUsuario.Size = new Size(220, 36);
            TextBoxUsuario.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.BackColor = Color.Transparent;
            txtContraseña.ForeColor = Color.Gray;
            txtContraseña.Location = new Point(40, 175);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(63, 17);
            txtContraseña.TabIndex = 3;
            txtContraseña.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.Transparent;
            txtUsuario.ForeColor = Color.Gray;
            txtUsuario.Location = new Point(40, 100);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(43, 17);
            txtUsuario.TabIndex = 4;
            txtUsuario.Text = "Usuario";
            // 
            // txtTitulo
            // 
            txtTitulo.BackColor = Color.Transparent;
            txtTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            txtTitulo.ForeColor = Color.FromArgb(44, 62, 80);
            txtTitulo.Location = new Point(11, 31);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(286, 27);
            txtTitulo.TabIndex = 5;
            txtTitulo.Text = "Sistema de Gestión\r\nBibliotecaria";
            txtTitulo.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 244, 246);
            ClientSize = new Size(800, 450);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Sistema Biblioteca";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtTitulo;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxUsuario;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtContraseña;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtUsuario;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxContraseña;
        private Guna.UI2.WinForms.Guna2Button btnIniciarSesion;
    }
}