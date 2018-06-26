using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Avaliacao.Dominio.Entidades;
using Uniplac.Avaliacao.Infra.Dados.Contexto;
using Uniplac.Avaliacao.Infra.Dados.Repositorios;
using Uniplac.Avaliacao.Testes.Base;

namespace Uniplac.Avaliacao.Testes.InfraTestes
{
    [TestClass]
    public class FuncionarioRepositorioTeste
    {
        private GerenciadorDeFrotaContexto _contextoTeste;
        private FuncionarioRepositorio _repositorio;
        private Funcionario _funcionarioTest;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<GerenciadorDeFrotaContexto>());

            _contextoTeste = new GerenciadorDeFrotaContexto();

            _repositorio = new FuncionarioRepositorio(_contextoTeste);

            _funcionarioTest = ConstrutorObjeto.CriarFuncionario();

            _contextoTeste.Database.Initialize(true);
        }
        [TestMethod]
        public void Deveria_adicionar_uma_novo_funcionario()
        {
            //Preparação

            //Ação
            _repositorio.Adicionar(_funcionarioTest);

            //Afirmar
            var todosFuncionarios = _contextoTeste.Funcionarios.ToList();

            Assert.AreEqual(2, todosFuncionarios.Count);
        }
        [TestMethod]
        public void Deveria_editar_um_funcionario()
        {
            var funcionarioEditado = _contextoTeste.Funcionarios.Find(1);
            funcionarioEditado.Nome = "EDITADO";

            _repositorio.Editar(funcionarioEditado);

            var funcionarioBuscado = _contextoTeste.Funcionarios.Find(1);

            Assert.AreEqual("EDITADO", funcionarioBuscado.Nome); ;
        }
        [TestMethod]
        public void Deveria_buscar_todos_os_funcionarios()
        {
            var FuncionarioBuscado = _repositorio.BuscarTudo();
            Assert.IsNotNull(FuncionarioBuscado);
        }
        [TestMethod]
        public void Deveria_deletar_um_funcionario()
        {
            var funcionarioDeletado = _contextoTeste.Funcionarios.Add(ConstrutorObjeto.CriarFuncionario());

            _repositorio.Deletar(funcionarioDeletado);

            var todosFuncionarios = _contextoTeste.Funcionarios.ToList();

            Assert.AreNotEqual(funcionarioDeletado, todosFuncionarios.Last());

        }
        [TestMethod]
        public void Deveria_buscar_funcionario_por_id()
        {
            var FuncionarioBuscado = _repositorio.BuscarPor(1);
            Assert.IsNotNull(FuncionarioBuscado);
        }
        [TestMethod]
        public void Deveria_buscar_funcionario_por_NumerodeRegistro()
        {
            var FuncionarioBuscado = _repositorio.BuscarPorNumeroDeRegistro(51);
            Assert.IsNotNull(FuncionarioBuscado);
        }
        [TestMethod]
        public void Deveria_buscar_Funcionario_por_nome()
        {

            var funcionarioBuscado = _repositorio.BuscarPorNome("Carlos Alfeu Marcon Andrade");

            Assert.IsNotNull(funcionarioBuscado);
        }
    }

}

