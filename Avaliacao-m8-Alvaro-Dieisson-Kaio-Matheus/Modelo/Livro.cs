using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao_m8_Alvaro_Dieisson_Kaio_Matheus.Modelo
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public bool Disponivel { get; set; }

        public Livro(int id, string titulo, string autor, int ano, bool disponivel)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Disponivel = disponivel;
        }
    }
}
