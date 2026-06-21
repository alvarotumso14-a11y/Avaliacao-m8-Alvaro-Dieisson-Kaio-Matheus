using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Avaliacao_m8_Alvaro_Dieisson_Kaio_Matheus.Servicos
{
    public class BibliotecaApiService
    {
        public async Task BuscarDetalhesApiAsync(string titulo)
        {
            try
            {
                using var client = new HttpClient();
                string url = $"https://openlibrary.org/search.json?title={titulo.Replace(" ", "+")}";
                string json = await client.GetStringAsync(url);

                var dados = JsonConvert.DeserializeObject<dynamic>(json);
                var doc = dados["docs"][0];

                string tituloApi = doc["title"];
                string autor = doc["author_name"][0];
                int ano = doc["first_publish_year"];

                Console.WriteLine($"Título: {tituloApi}");
                Console.WriteLine($"Autor: {autor}");
                Console.WriteLine($"Ano: {ano}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro de rede: {ex.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível obter os detalhes do livro.");
            }
        }
    }
}