using Avaliacao_m8_Alvaro_Dieisson_Kaio_Matheus.Execoes;
using Avaliacao_m8_Alvaro_Dieisson_Kaio_Matheus.Modelo;
using Newtonsoft.Json;
using ProjetoBiblioteca.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Avaliacao_m8_Alvaro_Dieisson_Kaio_Matheus.RepositorioLivro
{
    internal class RepositorioLivro : IRepositorioLivro
    {
        public List<Livro> Livros = new();
        public void Adicionar(Livro L)
        {
            Livros.Add(L);
        }
        public async Task<List<Livro>> ListarTodos()
        {
            Random random = new();
            {
                int tempo = random.Next(500, 2000);
                await Task.Delay(tempo);
            }
            return Livros;
        }

        public Livro BuscarPorId(int id)
        {
            var livro = Livros.FirstOrDefault(p => p.Id == id);
            return livro ?? throw new LivroNaoEncontradoExepition($"Id {id} nao encontrado!");
        }

        public List<Livro> BuscarPorAutor(string autor)
        {
            return Livros
                .Where(p => p.Autor == autor)
                .ToList();
        }

        public List<Livro> ExibirDisponiveis()
        {
            return Livros
                .Where(p => p.Disponivel == true)
                .ToList();
        }

        //json e nao json!
        public void SalvarAcervo()
        {
            string json = JsonConvert.SerializeObject(Livros, Formatting.Indented);
            File.WriteAllText("acervo.json", json);
        }

        public void CarregarAcervoJson()
        {
            if (File.Exists("acervo.json"))
            {
                string json = File.ReadAllText("acervo.json");
                Livros = JsonConvert.DeserializeObject<List<Livro>>(json) ?? new List<Livro>();
            }
        }












        public void ExibirTabelaLivros(List<Livro> livros)
        {
            var table = new ConsoleTable(
                "Id",
                "Título",
                "Autor",
                "Ano",
                "Disponível"
            );

            foreach (var livro in livros)
            {
                table.AddRow(
                    livro.Id,
                    livro.Titulo,
                    livro.Autor,
                    livro.Ano,
                    livro.Disponivel ? "Disponivel" : "Indisponivel"
                    );
            }

            table.Write();
        }
    }
}


