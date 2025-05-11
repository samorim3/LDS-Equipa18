/*


 UC: 21178 - Laborat�rio de Software
 Sistema de Reservas de Espa�os

 Vers�o 1
 Vers�o Inicial
 
 LDS-Equipa18
 Aluno respons�vel pelo c�digo: 2202009 - Vasco Lopes

 �ltima modifica��o : 11 / 05 / 2025


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
                // N�o interromper o programa caso o log falhe
            }
        }
    }
}