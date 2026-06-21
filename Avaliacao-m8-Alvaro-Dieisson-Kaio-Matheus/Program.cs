using Avaliacao_m8_Alvaro_Dieisson_Kaio_Matheus.Modelo;
using ProjetoBiblioteca.Interface;
using ProjetoBiblioteca.Modelo;
using ProjetoBiblioteca.RepositorioLivro;

//Banco de dados
var livros = new List<Livro>
{
    new Livro(1, "Dom Casmurro", "Machado de Assis", 1899, true),
    new Livro(2, "Memórias Póstumas de Brás Cubas", "Machado de Assis", 1881, true),
    new Livro(3, "Quincas Borba", "Machado de Assis", 1891, false),
    new Livro(4, "Esaú e Jacó", "Machado de Assis", 1904, true),
    new Livro(5, "A Mão e a Luva", "Machado de Assis", 1874, true),
    new Livro(6, "1984", "George Orwell", 1949, true),
    new Livro(7, "O Hobbit", "J. R. R. Tolkien", 1937, true),
    new Livro(8, "A Sociedade do Anel", "J. R. R. Tolkien", 1954, true),
    new Livro(9, "As Duas Torres", "J. R. R. Tolkien", 1954, false),
    new Livro(10, "O Retorno do Rei", "J. R. R. Tolkien", 1955, true),
    new Livro(11, "Harry Potter e a Pedra Filosofal", "J. K. Rowling", 1997, true),
    new Livro(12, "Harry Potter e a Câmara Secreta", "J. K. Rowling", 1998, true),
    new Livro(13, "Harry Potter e o Prisioneiro de Azkaban", "J. K. Rowling", 1999, false),
    new Livro(14, "Harry Potter e o Cálice de Fogo", "J. K. Rowling", 2000, true),
    new Livro(15, "Clean Code", "Robert C. Martin", 2008, true),
    new Livro(16, "Carrie", "Stephen King", 1974, true),
    new Livro(17, "O Iluminado", "Stephen King", 1977, true),
    new Livro(18, "It: A Coisa", "Stephen King", 1986, true),
    new Livro(19, "Misery", "Stephen King", 1987, false),
    new Livro(20, "Sob a Redoma", "Stephen King", 2009, false),
    new Livro(21, "Orgulho e Preconceito", "Jane Austen", 1813, true),
    new Livro(22, "Razão e Sensibilidade", "Jane Austen", 1811, true),
    new Livro(23, "Emma", "Jane Austen", 1815, false),
    new Livro(24, "O Código Da Vinci", "Dan Brown", 2003, true),
    new Livro(25, "A Guerra dos Tronos", "George R. R. Martin", 1996, true),
    new Livro(26, "A Fúria dos Reis", "George R. R. Martin", 1998, true),
    new Livro(27, "A Tormenta de Espadas", "George R. R. Martin", 2000, false),
    new Livro(28, "O Festim dos Corvos", "George R. R. Martin", 2005, true),
    new Livro(29, "O Alquimista", "Paulo Coelho", 1988, true),
    new Livro(30, "Brida", "Paulo Coelho", 1990, false),
    new Livro(31, "Veronika Decide Morrer", "Paulo Coelho", 1998, true)
};

//adiciona todos os livros para o repositorio
RepositorioLivro repositorio = new();
foreach (var livro in livros)
{
    repositorio.Adicionar(livro);
}
//garrega arquivo json ai iniciar
repositorio.CarregarAcervoJson();

int opcao = -1;
while (opcao != 0)
{
    Console.WriteLine("digite 1 - Listar todos os livros");
    Console.WriteLine("digite 2 - Buscar por Id");
    Console.WriteLine("digite 3 - Buscar Por Autor");
    Console.WriteLine("digite 4 - Listar Disponiveis");
    Console.WriteLine("digite 5 - Buscar na API");
    Console.WriteLine("digite 6 - Salvar Acervo");
    Console.WriteLine("digite 0 - Sair");
    Console.WriteLine("Qual opcao deseja realizar: ");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Carregando Lista de Livros...");
            repositorio.ExibirTabelaLivros(await repositorio.ListarTodos());
            break;

        case 2:
            Console.WriteLine("Qual ID deseja Buscar: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var buscaId = repositorio.BuscarPorId(id);
                Console.WriteLine($"{buscaId.Id} - {buscaId.Titulo} - {buscaId.Autor} - {buscaId.Ano} - {(buscaId.Disponivel ? "Disponível" : "Indisponível")}");
            }
            catch
            {
                Console.WriteLine("Caracter Invalido");
            }
            break;

        case 3:
            Console.WriteLine("Qual autor deseja buscar: ");
            string autor = Console.ReadLine();
            var buscaAutor = repositorio.BuscarPorAutor(autor);
            repositorio.ExibirTabelaLivros(buscaAutor);
            break;

        case 4:
            Console.WriteLine("Livros Disponiveis");
            repositorio.ExibirTabelaLivros(repositorio.ExibirDisponiveis());
            break;

        case 5:
            Console.WriteLine("Nao Conseguimos Fazer!");
            break;

        case 6:
            repositorio.SalvarAcervo();
            Console.WriteLine("Acero Salvo");
            break;

        case 0:
            Console.WriteLine("Programa Finalizado");
            break;

        default:
            Console.WriteLine("opcao invalida");
            break;
    }

}
