using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Avaliacao.Infra.Dados.Contexto;
using Uniplac.Avaliacao.Infra.Dados.Repositorios;
using Uniplac.Avaliacao.Dominio.Entidades;
using System.Data.Entity;
using Uniplac.Avaliacao.Testes.Base;
using System.Linq;

namespace Uniplac.Avaliacao.Testes.InfraTestes
{

    [TestClass]
    public class EmpresaRepositorioTeste
    {
        private GerenciadorDeFrotaContexto _contextoTeste;
        private EmpresaRepositorio _repositorio;
        private Empresa _empresaTest;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<GerenciadorDeFrotaContexto>());

            _contextoTeste = new GerenciadorDeFrotaContexto();

            _repositorio = new EmpresaRepositorio(_contextoTeste);

            _empresaTest = ConstrutorObjeto.CriarEmpresa();

            _contextoTeste.Database.Initialize(true);
        }
        [TestMethod]
        public void Deveria_adicionar_uma_nova_empresa()
        {
            //Preparação

            //Ação
            _repositorio.Adicionar(_empresaTest);

            //Afirmar
            var todasEmpresas = _contextoTeste.Empresas.ToList();

            Assert.AreEqual(2, todasEmpresas.Count);
        }
        [TestMethod]
        public void Deveria_editar_uma_nova_empresa()
        {
            var EmpresaEditada = _contextoTeste.Empresas.Find(1);
            EmpresaEditada.Nome = "EDITADO";

            _repositorio.Editar(EmpresaEditada);

            var EmpresaBuscada = _contextoTeste.Empresas.Find(1);

            Assert.AreEqual("EDITADO", EmpresaBuscada.Nome); ;
        }
        [TestMethod]
        public void Deveria_deletar_uma_emrpesa()
        {
            var empresaDeletada = _contextoTeste.Empresas.Add(ConstrutorObjeto.CriarEmpresa());

            _repositorio.Deletar(empresaDeletada);

            var todasEmpresas = _contextoTeste.Empresas.ToList();

            Assert.AreNotEqual(empresaDeletada, todasEmpresas.Last());
        }
        [TestMethod]
        public void Deveria_buscar_todos_as_empresas()
        {
            var EmpresaBuscada = _repositorio.BuscarTudo();
            Assert.IsNotNull(EmpresaBuscada);
        }
        [TestMethod]
        public void Deveria_buscar_funcionario_por_id()
        {
            var EmpresaBuscada = _repositorio.BuscarPor(1);
            Assert.IsNotNull(EmpresaBuscada);

        }
        [TestMethod]
        public void Deveria_buscar_Empresa_por_nome()
        {

            var EmpresaBuscada = _repositorio.BuscarPorNome("Fabricio Lang ME");

            Assert.IsNotNull(EmpresaBuscada);
        }
        [TestMethod]
        public void Deveria_buscar_Empresa_por_CNPJ()
        {

            var EmpresaBuscada = _repositorio.BuscarPorCNPJ("02515325005151");

            Assert.IsNotNull(EmpresaBuscada);
        }
    }
       
}
