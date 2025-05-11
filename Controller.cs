/*
 ============================================================================
 UC: 21178 - Laboratório de Software
 Projeto: Sistema de Reservas de Espaços
 Autor: João Flores (Aluno n.º 2301427)

 Este código faz parte do trabalho de grupo desenvolvido na unidade curricular.
 Integra-se com a lógica de reservas do colega Vasco Lopes (Model/Persistência).
 
 Última modificação: [11/05/2025]

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

        // Método para obter a lista de espaços disponíveis (todos os nomes de espaços com reservas)
        public static List<string> ObterEspacos()
        {
            try
            {
                return gestor.ObterNomesEspacos();
            }
            catch (Exception ex)
            {
                RegistoLogs.Escrever($"Erro em ObterEspacos: {ex.Message}");
                return new List<string>();
            }
        }

        // Método para obter a lista de espaços disponíveis para uma data/hora específica
        public static List<string> ObterEspacosDisponiveisPara(DateTime dataHora)
        {
            try
            {
                DateTime normalizado = dataHora.AddSeconds(-dataHora.Second).AddMilliseconds(-dataHora.Millisecond);
                var todosEspacos = gestor.ObterNomesEspacos();
                var disponiveis = new List<string>();

                foreach (var espaco in todosEspacos)
                {
                    if (gestor.VerificarDisponibilidade(espaco, normalizado))
                    {
                        disponiveis.Add(espaco);
                    }
                }

                return disponiveis;
            }
            catch (Exception ex)
            {
                RegistoLogs.Escrever($"Erro em ObterEspacosDisponiveisPara: {ex.Message}");
                return new List<string>();
            }
        }

        // Método para criar uma reserva e devolver a reserva criada, se for bem-sucedido
        public static bool CriarReserva(string nome, string espaco, DateTime dataHora, out Reserva reservaCriada)
        {
            reservaCriada = null;

            try
            {
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
            catch (Exception ex)
            {
                RegistoLogs.Escrever($"Erro em CriarReserva: {ex.Message}");
                return false;
            }
        }

        // Método para obter todas as reservas existentes
        public static List<Reserva> ObterReservas()
        {
            try
            {
                return gestor.ObterReservas();
            }
            catch (Exception ex)
            {
                RegistoLogs.Escrever($"Erro em ObterReservas: {ex.Message}");
                return new List<Reserva>();
            }
        }

        // Método para exportar a reserva para um ficheiro PDF
        public static void ExportarReservaParaPDF(Reserva reserva, string caminhoFicheiro)
        {
            try
            {
                PDFGenerator.GerarComprovativo(reserva, caminhoFicheiro);
            }
            catch (Exception ex)
            {
                RegistoLogs.Escrever($"Erro ao exportar PDF: {ex.Message}");
            }
        }
    }
}
