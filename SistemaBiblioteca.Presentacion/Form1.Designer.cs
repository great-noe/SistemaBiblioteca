// Uso de using
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaBiblioteca.Presentacion
{
    partial class Form1 : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        //Consructor inicializado
        public Form1()
        {
            InitializeComponent();
            
            // Configuración adicional recomendada
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 450);
            this.Text = "Sistema de Biblioteca";
            
            // Puedes inicializar controles aquí si es necesario
            InicializarControles();
        }

        /// <summary>
        /// Método para inicializar controles adicionales
        /// </summary>
        private void InicializarControles()
        {
            // Aquí puedes agregar controles dinámicamente
            // Ejemplo:
            // var label = new Label() { Text = "Bienvenido", Location = new Point(10, 10) };
            // this.Controls.Add(label);
        }

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            
            // Agrega controles básicos (opcional, pero recomendado)
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        }

        #endregion
    }
}
}
