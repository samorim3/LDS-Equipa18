/*
 ============================================================================
 UC: 21178 - Laboratório de Software
 Projeto: Sistema de Reservas de Espaços
 Autor: João Flores (Aluno n.º 2301427)

 Este código faz parte do trabalho de grupo desenvolvido na unidade curricular.
 Integra-se com a lógica de reservas do colega Vasco Lopes (Model/Persistência).
 
 Última modificação: [10/05/2025]

 ============================================================================
*/

using System;
using System.Windows.Forms;

namespace ReservaEspacos
{
    static class Program
    {
        // Método principal (Main) da aplicação
        [STAThread]
        static void Main()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // Define configurações visuais da aplicação
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Abre a janela principal (View)
            Application.Run(new View.Form1());
        }
    }
}
