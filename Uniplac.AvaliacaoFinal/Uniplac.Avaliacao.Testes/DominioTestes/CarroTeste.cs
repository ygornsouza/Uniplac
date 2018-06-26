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
    public class CarroTeste
    {
        private Carro _carro;

        [TestInitialize]
        public void Inicializador()
        {
            _carro = ConstrutorObjeto.CriarCarro();
        }

        [TestMethod]
        public void Carro_Deve_Ter_Modelo()
        {
            Assert.AreEqual("Civic", _carro.Modelo);
        }
        [TestMethod]
        public void Carro_Deve_Ter_Marca()
        {
            Assert.AreEqual("Honda", _carro.Marca);
        }
        [TestMethod]
        public void Carro_Deve_Ter_Ano()
        {
            Assert.AreEqual("2018", _carro.Ano);
        }
        [TestMethod]
        public void Carro_Deve_Ter_Placa()
        {
            Assert.AreEqual("MKZ1211", _carro.Placa);
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Carro_Deve_Ter_Modelo_Valido()
        {
            _carro.Modelo = "";
            _carro.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Carro_Deve_Ter_Marca_Valido()
        {
            _carro.Marca = "";
            _carro.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Carro_Deve_Ter_Ano_Valido()
        {
            _carro.Ano = "";
            _carro.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Carro_Deve_Ter_Placa_Valido()
        {
            _carro.Placa = "";
            _carro.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Carro_Deve_Ter_IDEmpresa_Valido()
        {
            _carro.Empresa = null;
            _carro.Validar();
        }


    }
}
