using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Avaliacao.Dominio.Entidades;
using Uniplac.Avaliacao.Infra.Dados.Contexto;

namespace Uniplac.Avaliacao.Testes.Base
{
    public class InicializadorBanco<T> : DropCreateDatabaseAlways<GerenciadorDeFrotaContexto>
    {
        protected override void Seed(GerenciadorDeFrotaContexto context)
        {
            Empresa empresa1 = new Empresa();
            empresa1.Nome = "Fabricio Lang ME";
            empresa1.CNPJ = "02515325005151";

            Funcionario funcionario1 = new Funcionario();
            funcionario1.Nome = "Carlos Alfeu Marcon Andrade";
            funcionario1.CPF = "02502502524";
            funcionario1.Cargo = "Presidente";
            funcionario1.NumeroDeRegistro = 51;

            Carro carro1 = new Carro();
            carro1.Modelo = "Palio Weekend";
            carro1.Marca = "Fiat";
            carro1.Placa = "JKT2536";
            carro1.Ano = "2018";
            carro1.Empresa = empresa1;

            Reserva reserva1 = new Reserva();
            reserva1.Carrro = carro1;
            reserva1.Data_Inicio_Reserva = new DateTime(2018, 12, 25, 12, 12, 12);
            reserva1.Data_Fim_Reserva= new DateTime(2018, 12, 26, 12, 12, 12);
            reserva1.Funcionario = funcionario1;
            reserva1.Observacao = "Vazio";

            context.Reservas.Add(reserva1);
            
            context.SaveChanges();

            base.Seed(context);


        }
    }
}
