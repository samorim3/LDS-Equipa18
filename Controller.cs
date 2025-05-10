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
using System.Collections.Generic;
using ReservaEspacos.Model;

namespace ReservaEspacos
{
    // Classe Controller: gere as interações entre a View e o Model
    public static class Controller
    {
        private static GestorReservas gestor = new GestorReservas();

        // Método para obter a lista de espaços disponíveis
        public static List<string> ObterEspacos()
        {
            return gestor.ObterNomesEspacos();
        }

        // Método para criar uma reserva e devolver a reserva criada, se for bem-sucedido
        public static bool CriarReserva(string nome, string espaco, DateTime dataHora, out Reserva reservaCriada)
        {
            reservaCriada = null;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(espaco))
                return false;

            var novaReserva = new Reserva
            {
                NomeUtilizador = nome,
                Espaco = espaco,
                DataHoraReserva = dataHora
            };

            bool sucesso = gestor.CriarReserva(novaReserva);

            if (sucesso)
                reservaCriada = novaReserva;

            return sucesso;
        }

        // Método para obter todas as reservas existentes
        public static List<Reserva> ObterReservas()
        {
            return gestor.ObterReservas();
        }

        // Método para exportar a reserva para um ficheiro PDF
        public static void ExportarReservaParaPDF(Reserva reserva, string caminhoFicheiro)
        {
            PDFGenerator.GerarComprovativo(reserva, caminhoFicheiro);
        }
    }
}
