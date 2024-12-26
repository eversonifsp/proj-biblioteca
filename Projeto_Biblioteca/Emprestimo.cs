using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    internal class Emprestimo
    {
        public DateTime DtEmprestimo { get; set; }
        public DateTime DtDevolucao { get; set; }
        public Emprestimo(DateTime dtEmprestimo, DateTime dtDevolucao)
        {
            DtEmprestimo = dtEmprestimo;
            DtDevolucao = dtDevolucao;
        }
    }
}
