using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Avaliacao.Dominio.Entidades;
using Uniplac.Avaliacao.Testes.Base;
using Uniplac.Avaliacao.Dominio.Excecoes;

namespace Uniplac.Avaliacao.Testes.DominioTestes
{
   
    [TestClass]
    public class ReservaTeste
    {
        private Reserva _reserva;

        [TestInitialize]
        public void Inicializador()
        {
            _reserva = ConstrutorObjeto.CriarReserva();
        }

        [TestMethod]
        public void Reserva_Deve_Ter_ID_Carro()
        {
        }
        [TestMethod]
        public void Reserva_Deve_Ter_ID_Funcionario()
        {
        }
        [TestMethod]
        public void Reserva_Deve_Ter_Data_de_inicio()
        {
            Assert.AreEqual(new DateTime(2018, 06, 24, 12, 00, 00), _reserva.Data_Inicio_Reserva);
        }
        [TestMethod]
        public void Reserva_Deve_Ter_Data_de_fim()
        {
            Assert.AreEqual(new DateTime(2018, 06, 26, 12, 00, 00), _reserva.Data_Fim_Reserva);
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Reserva_Deve_Ter_Data_de_fim_maior_que_inicio()
        {
            _reserva.Data_Inicio_Reserva = new DateTime(2018, 06, 28, 12, 00, 00);
            _reserva.Validar();
        }


    }
}
