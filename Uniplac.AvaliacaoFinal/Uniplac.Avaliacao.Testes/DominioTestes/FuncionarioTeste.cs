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
    public class FuncionarioTeste
    {
        private Funcionario _funcionario;

        [TestInitialize]
        public void Inicializador()
        {
            _funcionario = ConstrutorObjeto.CriarFuncionario();
        }

        [TestMethod]
        public void Funcionario_Deve_Ter_Nome()
        {
            Assert.AreEqual("Ygor Souza Nunes", _funcionario.Nome);
        }
        [TestMethod]
        public void Funcionario_Deve_Ter_Cargo()
        {
            Assert.AreEqual("Assistente de TI", _funcionario.Cargo);
        }
        [TestMethod]
        public void Funcionario_Deve_Ter_CPF()
        {
            Assert.AreEqual("11507218982", _funcionario.CPF);
        }
        [TestMethod]
        public void Funcionario_Deve_Ter_NumeroDeRegistro()
        {
            Assert.AreEqual(65, _funcionario.NumeroDeRegistro);
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Funcionario_Deve_Ter_Nome_Valido()
        {
            _funcionario.Nome = "";
            _funcionario.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Funcionario_Deve_Ter_Cargo_Valido()
        {
            _funcionario.Cargo = "";
            _funcionario.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Funcionario_Deve_Ter_CPF_Valido()
        {
            _funcionario.CPF = "";
            _funcionario.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Funcionario_Deve_Ter_NumeroDeRegistro_Valido()
        {
            _funcionario.NumeroDeRegistro = 0;
            _funcionario.Validar();
        }
    }
}
