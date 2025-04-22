/*


 UC: 21178 - Laboratório de Software
 Sistema de Reservas de Espaços

 Versão 1
 Versão inicial
 
 LDS-Equipa18
 Aluno responsável pelo código: 2202009 - Vasco Lopes

 Última modificação : 21 / 04 / 2025


 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ReservaEspacos.Model
{
    public class PersistenciaDados
    {
        private readonly string caminhoFicheiro = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\reservas.json");

        public List<Espaco> Carregar()
        {
            if (!File.Exists(caminhoFicheiro))
                return new List<Espaco>();

            string json = File.ReadAllText(caminhoFicheiro);
            return JsonSerializer.Deserialize<List<Espaco>>(json) ?? new List<Espaco>();
        }

        public void Guardar(List<Espaco> espacos)
        {
            string pasta = Path.GetDirectoryName(caminhoFicheiro);

            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            string json = JsonSerializer.Serialize(espacos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoFicheiro, json);
        }
    }
}