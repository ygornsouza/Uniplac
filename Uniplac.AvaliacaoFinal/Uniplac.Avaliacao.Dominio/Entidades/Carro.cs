using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Avaliacao.Dominio.Excecoes;

namespace Uniplac.Avaliacao.Dominio.Entidades
{
    public class Carro
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Ano { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public Empresa Empresa { get; set; }

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(Marca))
                throw new DominioException("Marca inválido!");
            if (String.IsNullOrWhiteSpace(Ano))
                throw new DominioException("Ano inválido!");
            if (String.IsNullOrWhiteSpace(Modelo))
                throw new DominioException("Modelo inválido!");
            if (String.IsNullOrWhiteSpace(Placa))
                throw new DominioException("CNPJ inválido!");
            if (Empresa == null)
                throw new DominioException("ID_Empresa inválido!");
        }
    }
}
