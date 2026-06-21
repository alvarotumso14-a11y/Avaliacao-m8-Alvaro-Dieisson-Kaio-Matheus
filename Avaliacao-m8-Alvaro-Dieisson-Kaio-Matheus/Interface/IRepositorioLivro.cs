using Avaliacao_m8_Alvaro_Dieisson_Kaio_Matheus.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBiblioteca.Interface
{
    public interface IRepositorioLivro
    {
        void Adicionar(Livro livro);
        Task<List<Livro>> ListarTodos();
        Livro BuscarPorId(int id);

        List<Livro> BuscarPorAutor(string autor);
    }
}
