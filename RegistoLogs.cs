/*


 UC: 21178 - Laboratório de Software
 Sistema de Reservas de Espaços

 Versão 1
 Versão Inicial
 
 LDS-Equipa18
 Aluno responsável pelo código: 2202009 - Vasco Lopes

 Última modificação : 11 / 05 / 2025


 */
using System;
using System.IO;

namespace ReservaEspacos
{
    public static class RegistoLogs
    {
        private static readonly string caminhoLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\log_reservas.txt");

        public static void Escrever(string mensagem)
        {
            try
            {
                File.AppendAllText(caminhoLog, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {mensagem}{Environment.NewLine}");
            }
            catch
            {
                // Não interromper o programa caso o log falhe
            }
        }
    }
}