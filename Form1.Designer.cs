namespace ReservaEspacos.View
{
    partial class Form1
    {
        // Componentes visuais da janela
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnVerEspacos;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEspaco;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblEspaco;
        private System.Windows.Forms.Label lblData;

        // Libertar memória quando o formulário for fechado
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Método que configura todos os elementos gráficos da janela
        private void InitializeComponent()
        {
            this.btnVerEspacos = new System.Windows.Forms.Button();
            this.btnReservar = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEspaco = new System.Windows.Forms.TextBox();
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

            // Caixa de texto para o espaço
            this.txtEspaco.Location = new System.Drawing.Point(150, 47);
            this.txtEspaco.Size = new System.Drawing.Size(200, 23);

            // Label "Data e hora"
            this.lblData.Location = new System.Drawing.Point(12, 85);
            this.lblData.Size = new System.Drawing.Size(120, 20);
            this.lblData.Text = "Data e hora:";

            // Picker de data e hora
            this.datePicker.Location = new System.Drawing.Point(150, 82);
            this.datePicker.Size = new System.Drawing.Size(200, 23);
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.CustomFormat = "dd/MM/yyyy HH:mm"; // Mostra data e hora
            this.datePicker.ShowUpDown = true; // Usa setas em vez de calendário

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

            // Propriedades do formulário
            this.ClientSize = new System.Drawing.Size(384, 181);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblEspaco);
            this.Controls.Add(this.txtEspaco);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.btnVerEspacos);
            this.Controls.Add(this.btnReservar);
            this.Name = "Form1";
            this.Text = "Reserva de Espaços";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
