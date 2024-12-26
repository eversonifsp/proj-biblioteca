namespace Projeto_Biblioteca
{
    internal class Program
    {
        static Livros biblioteca = new Livros();
        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: AdicionarLivro(); break;
                    case 2: PesquisarLivroSintetico(); break;
                    case 3: PesquisarLivroAnalitico(); break;
                    case 4: AdicionarExemplar(); break;
                    case 5: RegistrarEmprestimo(); break;
                    case 6: RegistrarDevolucao(); break;
                    case 0: break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }

        static void AdicionarLivro()
        {
            Console.Write("Informe o ISBN: ");
            int isbn = int.Parse(Console.ReadLine());
            Console.Write("Informe o título: ");
            string titulo = Console.ReadLine();
            Console.Write("Informe o autor: ");
            string autor = Console.ReadLine();
            Console.Write("Informe a editora: ");
            string editora = Console.ReadLine();

            Livro livro = new Livro(isbn, titulo, autor, editora);
            biblioteca.Adicionar(livro);
            Console.WriteLine("Livro adicionado com sucesso!");
        }

        static void PesquisarLivroSintetico()
        {
            Console.Write("Informe o título ou ISBN do livro: ");
            string input = Console.ReadLine();
            Livro livro = new Livro(0, input, "", "");
            livro.Isbn = int.TryParse(input, out int isbn) ? isbn : 0;

            Livro livroEncontrado = biblioteca.Pesquisar(livro);
            if (livroEncontrado != null)
            {
                Console.WriteLine($"Título: {livroEncontrado.Titulo}");
                Console.WriteLine($"Autor: {livroEncontrado.Autor}");
                Console.WriteLine($"Exemplares: {livroEncontrado.QtdeExemplares()}");
                Console.WriteLine($"Disponíveis: {livroEncontrado.QtdeDisponiveis()}");
                Console.WriteLine($"Empréstimos: {livroEncontrado.QtdeEmprestimos()}");
                Console.WriteLine($"Disponibilidade: {livroEncontrado.PercDisponibilidade():F2}%");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void PesquisarLivroAnalitico()
        {
            Console.Write("Informe o título ou ISBN do livro: ");
            string input = Console.ReadLine();
            Livro livro = new Livro(0, input, "", "");
            livro.Isbn = int.TryParse(input, out int isbn) ? isbn : 0;

            Livro livroEncontrado = biblioteca.Pesquisar(livro);
            if (livroEncontrado != null)
            {
                Console.WriteLine($"Título: {livroEncontrado.Titulo}");
                Console.WriteLine($"Autor: {livroEncontrado.Autor}");
                Console.WriteLine($"Exemplares: {livroEncontrado.QtdeExemplares()}");
                Console.WriteLine($"Disponíveis: {livroEncontrado.QtdeDisponiveis()}");
                Console.WriteLine($"Empréstimos: {livroEncontrado.QtdeEmprestimos()}");
                Console.WriteLine($"Disponibilidade: {livroEncontrado.PercDisponibilidade():F2}%");
                Console.WriteLine("Detalhes dos exemplares:");
                foreach (var exemplar in livroEncontrado.Exemplares)
                {
                    Console.WriteLine($"Tombo: {exemplar.Tombo} | Disponível: {exemplar.disponivel()} | Empréstimos: {exemplar.QtdeEmprestimos()}");
                    foreach (var emprestimo in exemplar.Emprestimos)
                    {
                        Console.WriteLine($"  Empréstimo em: {emprestimo.DtEmprestimo} | Devolução: {emprestimo.DtDevolucao}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void AdicionarExemplar()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(new Livro(isbn, "", "", ""));
            if (livro != null)
            {
                Console.Write("Informe o tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine());

                Exemplar exemplar = new Exemplar(tombo);
                livro.AdicionarExemplar(exemplar);
                Console.WriteLine("Exemplar adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarEmprestimo()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(new Livro(isbn, "", "", ""));
            if (livro != null)
            {
                Console.Write("Informe o tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine());
                Exemplar exemplar = livro.Exemplares.FirstOrDefault(e => e.Tombo == tombo);
                if (exemplar != null && exemplar.Emprestar())
                {
                    Console.WriteLine("Empréstimo registrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Exemplar não disponível para empréstimo.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarDevolucao()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(new Livro(isbn, "", "", ""));
            if (livro != null)
            {
                Console.Write("Informe o tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine());
                Exemplar exemplar = livro.Exemplares.FirstOrDefault(e => e.Tombo == tombo);
                if (exemplar != null && exemplar.Devolver())
                {
                    Console.WriteLine("Devolução registrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Exemplar não encontrado ou não estava emprestado.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
    }
}
