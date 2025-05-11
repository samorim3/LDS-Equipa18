/*


 UC: 21178 - Laborat�rio de Software
 Sistema de Reservas de Espa�os

 Vers�o 2
 Integra��o com RegistoLogs e gest�o de erros
 
 LDS-Equipa18
 Aluno respons�vel pelo c�digo: 2202009 - Vasco Lopes

 �ltima modifica��o : 11 / 05 / 2025


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
                    RegistoLogs.Escrever("O ficheiro de dados n�o foi localizado. Ser� criado um novo.");
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
