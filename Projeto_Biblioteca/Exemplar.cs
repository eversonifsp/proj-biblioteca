using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    internal class Exemplar
    {
        public int Tombo { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }
        public Exemplar(int tombo)
        {
            Tombo = tombo;
            Emprestimos = new List<Emprestimo>();
        }

        public bool Emprestar()
        {
            if (disponivel())
            {
                Emprestimos.Add(new Emprestimo(DateTime.Now, DateTime.MinValue));
                return true;
            }
            return false;
        }

        public bool Devolver()
        {
            var emprestimo = Emprestimos.FirstOrDefault(e => e.DtDevolucao == DateTime.MinValue);
            if (emprestimo != null)
            {
                emprestimo.DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool disponivel()
        {
            return !Emprestimos.Any(e => e.DtDevolucao == DateTime.MinValue);
        }

        public int QtdeEmprestimos()
        {
            return Emprestimos.Count;
        }
    }
}
