using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    internal class Livro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public List<Exemplar> Exemplares { get; set; }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Exemplares = new List<Exemplar>();
        }

        public void AdicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }

        public int QtdeExemplares()
        {
            return Exemplares.Count;
        }

        public int QtdeDisponiveis()
        {
            return Exemplares.Count(e => e.disponivel());
        }

        public int QtdeEmprestimos()
        {
            return Exemplares.Sum(e => e.QtdeEmprestimos());
        }

        public double PercDisponibilidade()
        {
            return QtdeExemplares() == 0 ? 0 : (double)QtdeDisponiveis() / QtdeExemplares() * 100;
        }
    }
}
