/*
 ============================================================================
 UC: 21178 - Laboratório de Software
 Projeto: Sistema de Reservas de Espaços
 Autor: João Flores (Aluno n.º 2301427)

 Este código faz parte do trabalho de grupo desenvolvido na unidade curricular.
 Integra-se com a lógica de reservas do colega Vasco Lopes (Model/Persistência).
 
 Última modificação: [23/04/2025]

 ============================================================================
*/

namespace ReservaEspacos.View
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnVerEspacos;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnVerReservas;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ComboBox cmbEspaco;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblEspaco;
        private System.Windows.Forms.Label lblData;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnVerEspacos = new System.Windows.Forms.Button();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnVerReservas = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cmbEspaco = new System.Windows.Forms.ComboBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblEspaco = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Label "Nome do utilizador"
            this.lblNome.Location = new System.Drawing.Point(12, 15);
            this.lblNome.Size = new System.Drawing.Size(120, 20);
            this.lblNome.Text = "Nome do utilizador:";

            // Caixa de texto para o nome
            this.txtNome.Location = new System.Drawing.Point(150, 12);
            this.txtNome.Size = new System.Drawing.Size(200, 23);

            // Label "Espaço a reservar"
            this.lblEspaco.Location = new System.Drawing.Point(12, 50);
            this.lblEspaco.Size = new System.Drawing.Size(120, 20);
            this.lblEspaco.Text = "Espaço a reservar:";

            // ComboBox para o espaço
            this.cmbEspaco.Location = new System.Drawing.Point(150, 47);
            this.cmbEspaco.Size = new System.Drawing.Size(200, 23);
            this.cmbEspaco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Label "Data e hora"
            this.lblData.Location = new System.Drawing.Point(12, 85);
            this.lblData.Size = new System.Drawing.Size(120, 20);
            this.lblData.Text = "Data e hora:";

            // Picker de data e hora
            this.datePicker.Location = new System.Drawing.Point(150, 82);
            this.datePicker.Size = new System.Drawing.Size(200, 23);
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            this.datePicker.ShowUpDown = true;

            // Botão "Ver espaços disponíveis"
            this.btnVerEspacos.Location = new System.Drawing.Point(12, 130);
            this.btnVerEspacos.Size = new System.Drawing.Size(150, 30);
            this.btnVerEspacos.Text = "Ver espaços disponíveis";
            this.btnVerEspacos.Click += new System.EventHandler(this.btnVerEspacos_Click);

            // Botão "Reservar espaço"
            this.btnReservar.Location = new System.Drawing.Point(200, 130);
            this.btnReservar.Size = new System.Drawing.Size(150, 30);
            this.btnReservar.Text = "Reservar espaço";
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);

            // Botão "Ver reservas existentes"
            this.btnVerReservas.Location = new System.Drawing.Point(12, 170);
            this.btnVerReservas.Size = new System.Drawing.Size(338, 30);
            this.btnVerReservas.Text = "Ver reservas existentes";
            this.btnVerReservas.Click += new System.EventHandler(this.btnVerReservas_Click);

            // Propriedades do formulário
            this.ClientSize = new System.Drawing.Size(384, 220);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblEspaco);
            this.Controls.Add(this.cmbEspaco);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.btnVerEspacos);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.btnVerReservas);
            this.Name = "Form1";
            this.Text = "Reserva de Espaços";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
