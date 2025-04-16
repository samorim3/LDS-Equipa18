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
            // Define configurações visuais da aplicação
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Abre a janela principal (View)
            Application.Run(new View.Form1());
        }
    }
}
