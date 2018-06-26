using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Avaliacao.Dominio.Entidades;

namespace Uniplac.Avaliacao.Testes.Base
{
    public static class ConstrutorObjeto
    {
        public static Funcionario CriarFuncionario()
        {
            return new Funcionario
            {
                Id = 1,
                Nome = "Ygor Souza Nunes",
                Cargo = "Assistente de TI",
                CPF = "11507218982",
                NumeroDeRegistro = 65
            };
        }

        public static Reserva CriarReserva()
        {
            return new Reserva
            {
                Id = 1,
                Carrro = CriarCarro(),
                Funcionario = CriarFuncionario(),
                Data_Fim_Reserva = new DateTime(2018, 06, 26, 12, 00, 00),
                Data_Inicio_Reserva = new DateTime(2018, 06, 24, 12, 00, 00),
                Observacao = "Observação"
        };
    
        }

        public static Empresa CriarEmpresa()
        {
            return new Empresa
            {
                Id = 1,
                Nome = "Comercial Assis Souza LTDA",
                CNPJ = "01692448000186"
            };
        }

        public static Carro CriarCarro()
        {
            return new Carro
            {
                Id = 1,
                Modelo = "Civic",
                Marca = "Honda",
                Placa = "MKZ1211",
                Ano = "2018",
                Empresa  = CriarEmpresa()
            };
        }
    }
}
