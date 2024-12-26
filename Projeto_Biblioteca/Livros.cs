using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    internal class Livros
    {
        public List<Livro> Acervo { get; set; }
        public Livros()
        {
            Acervo = new List<Livro>();
        }

        public void Adicionar(Livro livro)
        {
            Acervo.Add(livro);
        }

        public Livro Pesquisar(Livro livro)
        {
            return Acervo.FirstOrDefault(l => l.Isbn == livro.Isbn || l.Titulo.Equals(livro.Titulo, StringComparison.OrdinalIgnoreCase));
        }
    }
}
