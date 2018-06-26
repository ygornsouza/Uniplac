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
    public class EmpresaTeste
    {
        private Empresa _empresa;

        [TestInitialize]
        public void Inicializador()
        {
            _empresa = ConstrutorObjeto.CriarEmpresa();
        }

        [TestMethod]
        public void Empresa_Deve_Ter_Nome()
        {
            Assert.AreEqual("Comercial Assis Souza LTDA", _empresa.Nome);
        }
        [TestMethod]
        public void Empresa_Deve_Ter_CNPJ()
        {
            Assert.AreEqual("01692448000186", _empresa.CNPJ);
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Empresa_Deve_Ter_Nome_Valido()
        {
            _empresa.Nome = "";
            _empresa.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Empresa_Deve_Ter_CNPJ_Valido()
        {
            _empresa.CNPJ = "";
            _empresa.Validar();
        }

    }
}
