using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Avaliacao.Dominio.Excecoes;

namespace Uniplac.Avaliacao.Dominio.Entidades
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public int NumeroDeRegistro { get; set; }
        public string CPF { get; set; }

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(Nome))
                throw new DominioException("Nome inválido!");
            if (String.IsNullOrWhiteSpace(Cargo))
                throw new DominioException("Cargo inválido!");
            if (NumeroDeRegistro < 1)
                throw new DominioException("Numero De Registro inválido!");
            if (String.IsNullOrWhiteSpace(CPF))
                throw new DominioException("CPF inválido!");
        }
    }
}
