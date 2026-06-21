using ProjetoBiblioteca.Modelo;
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
        List<Livro> ListarTodos();
        Livro BuscarPorId(int id);

        List<Livro> BuscarPorAutor(string autor);
    }
}
