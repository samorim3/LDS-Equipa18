/*
 UC: 21178 - Laborat�rio de Software
 Sistema de Reservas de Espa�os

 Vers�o 5
 Integra��o com RegistoLogs e gest�o de erros

 LDS-Equipa18
 Aluno respons�vel pelo c�digo: 2202009 - Vasco Lopes

 �ltima modifica��o : 11 / 05 / 2025
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace ReservaEspacos.Model
{
    // Representa uma reserva efetuada por um utilizador
    public class Reserva
    {
        public string NomeUtilizador { get; set; }
        public DateTime DataHoraReserva { get; set; }
        public string Espaco { get; set; }
    }

    // Representa um espa�o dispon�vel para reserva
    public class Espaco
    {
        public string NomeEspaco { get; set; }
        public List<Reserva> Reservas { get; set; }

        public Espaco()
        {
            Reservas = new List<Reserva>();
        }
    }

    // Respons�vel por gerir os espa�os e reservas
    public class GestorReservas
    {
        private List<Espaco> espacos;
        private PersistenciaDados persistencia;

        public GestorReservas()
        {
            try
            {
                persistencia = new PersistenciaDados();
                espacos = persistencia.Carregar();
                RegistoLogs.Escrever("Dados carregados com sucesso.");
            }
            catch (Exception ex)
            {
                espacos = new List<Espaco>();
                RegistoLogs.Escrever($"Erro ao carregar dados: {ex.Message}");
            }
        }

        // Guardar os dados -> persist�ncia
        private void GuardarDados()
        {
            try
            {
                persistencia.Guardar(espacos);
                RegistoLogs.Escrever("Dados guardados com sucesso.");
            }
            catch (Exception ex)
            {
                RegistoLogs.Escrever($"Erro ao guardar dados: {ex.Message}");
            }
        }

        // Verifica se um espa�o est� dispon�vel numa dada data/hora
        public bool VerificarDisponibilidade(string nomeEspaco, DateTime dataHora)
        {
            var espaco = espacos.FirstOrDefault(e => e.NomeEspaco == nomeEspaco);
            if (espaco == null) return true;

            // Arredonda a data/hora para os minutos (ignora segundos e milissegundos, para facilitar a dete��o de duplicados)
            DateTime alvo = new DateTime(dataHora.Year, dataHora.Month, dataHora.Day, dataHora.Hour, dataHora.Minute, 0);

            return !espaco.Reservas.Any(r =>
            {
                DateTime reserva = new DateTime(r.DataHoraReserva.Year, r.DataHoraReserva.Month, r.DataHoraReserva.Day,
                                                r.DataHoraReserva.Hour, r.DataHoraReserva.Minute, 0);
                return reserva == alvo;
            });
        }

        // Cria uma nova reserva, se for poss�vel
        public bool CriarReserva(Reserva novaReserva)
        {
            try
            {
                // Arredonda a data/hora da nova reserva, para terminar em minutos
                novaReserva.DataHoraReserva = new DateTime(
                    novaReserva.DataHoraReserva.Year,
                    novaReserva.DataHoraReserva.Month,
                    novaReserva.DataHoraReserva.Day,
                    novaReserva.DataHoraReserva.Hour,
                    novaReserva.DataHoraReserva.Minute,
                    0
                );

                // Tenta encontrar o espa�o
                var espaco = espacos.FirstOrDefault(e => e.NomeEspaco == novaReserva.Espaco);

                // Se n�o existir, cria novo
                if (espaco == null)
                {
                    espaco = new Espaco { NomeEspaco = novaReserva.Espaco };
                    espacos.Add(espaco);
                }

                // Verificar a disponibilidade
                if (!VerificarDisponibilidade(novaReserva.Espaco, novaReserva.DataHoraReserva))
                {
                    RegistoLogs.Escrever($"Reserva rejeitada: Espa�o '{novaReserva.Espaco}' indispon�vel para {novaReserva.DataHoraReserva}.");
                    return false;
                }

                // Adicionar a reserva e guardar
                espaco.Reservas.Add(novaReserva);
                GuardarDados();
                RegistoLogs.Escrever($"Reserva criada: {novaReserva.NomeUtilizador} - {novaReserva.Espaco} - {novaReserva.DataHoraReserva}");
                return true;
            }
            catch (Exception ex)
            {
                RegistoLogs.Escrever($"Erro ao criar reserva: {ex.Message}");
                return false;
            }
        }

        // Retornar todos os nomes de espa�os com pelo menos uma reserva
        public List<string> ObterNomesEspacos()
        {
            return espacos.Select(e => e.NomeEspaco).ToList();
        }

        // Devolver todas as reservas j� efetuadas
        public List<Reserva> ObterReservas()
        {
            return espacos.SelectMany(e => e.Reservas).ToList();
        }
    }
}