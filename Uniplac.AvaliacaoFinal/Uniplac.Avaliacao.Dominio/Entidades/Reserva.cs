using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Avaliacao.Dominio.Excecoes;

namespace Uniplac.Avaliacao.Dominio.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }
        public Carro Carrro { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime Data_Inicio_Reserva { get; set; }
        public DateTime Data_Fim_Reserva { get; set; }
        public string Observacao { get; set; }


        public void Validar()
        {
            if (Data_Inicio_Reserva > Data_Fim_Reserva)
                throw new DominioException("Data de inicio menor que data de Fim!");
        }
    }
}
