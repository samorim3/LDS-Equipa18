/*
 UC: 21178 - Laboratório de Software
 Sistema de Reservas de Espaços

 Versão 3
 Separação da lógica de persistência em classe externa

 LDS-Equipa18
 Aluno responsável pelo código: 2202009 - Vasco Lopes

 Última modificação : 22 / 04 / 2025
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

    // Representa um espaço disponível para reserva
    public class Espaco
    {
        public string NomeEspaco { get; set; }
        public List<Reserva> Reservas { get; set; }

        public Espaco()
        {
            Reservas = new List<Reserva>();
        }
    }

    // Responsável por gerir os espaços e reservas
    public class GestorReservas
    {
        private List<Espaco> espacos;
        private PersistenciaDados persistencia;

        public GestorReservas()
        {
            persistencia = new PersistenciaDados();
            espacos = persistencia.Carregar();
        }

        // Guardar os dados -> persistência
        private void GuardarDados()
        {
            persistencia.Guardar(espacos);
        }

        // Verifica se um espaço está disponível numa dada data/hora
        public bool VerificarDisponibilidade(string nomeEspaco, DateTime dataHora)
        {
            var espaco = espacos.FirstOrDefault(e => e.NomeEspaco == nomeEspaco);
            if (espaco == null) return true;

            return !espaco.Reservas.Any(r => r.DataHoraReserva == dataHora);
        }

        // Cria uma nova reserva, se for possível
        public bool CriarReserva(Reserva novaReserva)
        {
            // Tenta encontrar o espaço
            var espaco = espacos.FirstOrDefault(e => e.NomeEspaco == novaReserva.Espaco);

            // Se não existir, cria novo
            if (espaco == null)
            {
                espaco = new Espaco { NomeEspaco = novaReserva.Espaco };
                espacos.Add(espaco);
            }

            // Verificar a disponibilidade
            if (!VerificarDisponibilidade(novaReserva.Espaco, novaReserva.DataHoraReserva))
            {
                return false;
            }

            // Adicionar a reserva e guardar
            espaco.Reservas.Add(novaReserva);
            GuardarDados();
            return true;
        }

        // Retornar todos os nomes de espaços com pelo menos uma reserva
        public List<string> ObterNomesEspacos()
        {
            return espacos.Select(e => e.NomeEspaco).ToList();
        }

        // Devolver todas as reservas já efetuadas
        public List<Reserva> ObterReservas()
        {
            return espacos.SelectMany(e => e.Reservas).ToList();
        }
    }
}