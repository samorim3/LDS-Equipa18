using System;
using System.Windows.Forms;

namespace ReservaEspacos.View
{
    // Form1: janela principal da aplicação
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Inicializa todos os elementos visuais (labels, inputs, botões)
        }

        // Evento do botão "Ver espaços disponíveis"
        private void btnVerEspacos_Click(object sender, EventArgs e)
        {
            // Chama o controller para obter os espaços e mostra numa janela
            var espacos = Controller.ObterEspacos();
            MessageBox.Show(string.Join("\n", espacos), "Espaços disponíveis");
        }

        // Evento do botão "Reservar espaço"
        private void btnReservar_Click(object sender, EventArgs e)
        {
            // Recolhe os dados inseridos pelo utilizador
            string nome = txtNome.Text;
            string espaco = txtEspaco.Text;
            DateTime data = datePicker.Value;

            // Envia os dados para o Controller
            bool sucesso = Controller.CriarReserva(nome, espaco, data);

            // Mostra mensagem conforme o resultado
            if (sucesso)
                MessageBox.Show("Reserva criada com sucesso!");
            else
                MessageBox.Show("Erro ao criar reserva.");
        }
    }
}
