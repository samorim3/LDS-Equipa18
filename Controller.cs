using System;
using System.Collections.Generic;

namespace ReservaEspacos
{
    // Classe Controller: gere as interações entre a View e o Model
    public static class Controller
    {
        // Lista simulada de espaços (até o Model real ser implementado)
        private static List<string> espacos = new List<string>
        {
            "Sala de Estudo 1",
            "Sala de Estudo 2",
            "Auditório",
            "Laboratório"
        };

        // Método para obter a lista de espaços disponíveis
        public static List<string> ObterEspacos()
        {
            return espacos;
        }

        // Método para criar uma reserva (simulado)
        public static bool CriarReserva(string nome, string espaco, DateTime dataHora)
        {
            // Aqui futuramente será chamada a lógica do Model (ex: verificar disponibilidade)
            return true; // Simula sucesso da reserva
        }
    }
}
