/*


 UC: 21178 - Laboratório de Software
 Sistema de Reservas de Espaços

 Versão 2
 Integração com RegistoLogs e gestão de erros
 
 LDS-Equipa18
 Aluno responsável pelo código: 2202009 - Vasco Lopes

 Última modificação : 11 / 05 / 2025


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
            try
            {
                if (!File.Exists(caminhoFicheiro))
                {
                    RegistoLogs.Escrever("O ficheiro de dados não foi localizado. Será criado um novo.");
                    return new List<Espaco>();
                }

                string json = File.ReadAllText(caminhoFicheiro);
                var dados = JsonSerializer.Deserialize<List<Espaco>>(json);
                RegistoLogs.Escrever("Os dados foram carregados do ficheiro com sucesso.");
                return dados ?? new List<Espaco>();
            }
            catch (Exception ex)
            {
                RegistoLogs.Escrever($"Erro ao carregar os dados do ficheiro: {ex.Message}");
                return new List<Espaco>(); // fallback seguro
            }
        }

        public void Guardar(List<Espaco> espacos)
        {
            try
            {
                string pasta = Path.GetDirectoryName(caminhoFicheiro);

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                string json = JsonSerializer.Serialize(espacos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(caminhoFicheiro, json);
                RegistoLogs.Escrever("Os dados foram gravados no ficheiro com sucesso.");
            }
            catch (Exception ex)
            {
                RegistoLogs.Escrever($"Erro ao gravar os dados no ficheiro: {ex.Message}");
            }
        }
    }
}
