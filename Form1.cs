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

using System;
using System.Windows.Forms;

namespace ReservaEspacos.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Preencher o ComboBox com os espaços disponíveis
            var espacos = Controller.ObterEspacos();
            cmbEspaco.Items.Clear();
            foreach (var espaco in espacos)
                cmbEspaco.Items.Add(espaco);

            // Selecionar o primeiro item por defeito, se houver
            if (cmbEspaco.Items.Count > 0)
                cmbEspaco.SelectedIndex = 0;
        }

        // Evento do botão "Ver espaços disponíveis"
        private void btnVerEspacos_Click(object sender, EventArgs e)
        {
            var espacos = Controller.ObterEspacos();
            MessageBox.Show(string.Join("\n", espacos), "Espaços disponíveis");
        }

        // Evento do botão "Reservar espaço"
        private void btnReservar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string espaco = cmbEspaco.SelectedItem?.ToString() ?? "";
            DateTime data = datePicker.Value;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(espaco))
            {
                MessageBox.Show("Por favor preencha todos os campos.");
                return;
            }

            bool sucesso = Controller.CriarReserva(nome, espaco, data);

            if (sucesso)
                MessageBox.Show("Reserva criada com sucesso!");
            else
                MessageBox.Show("Erro: o espaço já está reservado para essa data/hora.");
        }

        // Evento do botão "Ver reservas existentes"
        private void btnVerReservas_Click(object sender, EventArgs e)
        {
            var reservas = Controller.ObterReservas();
            if (reservas.Count == 0)
            {
                MessageBox.Show("Nenhuma reserva encontrada.");
                return;
            }

            string texto = string.Join("\n\n", reservas.ConvertAll(r =>
                $"Nome: {r.NomeUtilizador}\nEspaço: {r.Espaco}\nData: {r.DataHoraReserva:dd/MM/yyyy HH:mm}"
            ));

            MessageBox.Show(texto, "Reservas existentes");
        }
    }
}
