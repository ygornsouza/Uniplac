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
    public class CarroRepositorioTeste
    {

        private GerenciadorDeFrotaContexto _contextoTeste;
        private CarroRepositorio _repositorio;
        private Carro _carroTest;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<GerenciadorDeFrotaContexto>());

            _contextoTeste = new GerenciadorDeFrotaContexto();

            _repositorio = new CarroRepositorio(_contextoTeste);

            _carroTest = ConstrutorObjeto.CriarCarro();

            _contextoTeste.Database.Initialize(true);
        }
        [TestMethod]
        public void Deveria_adicionar_uma_nova_carro()
        {

            _repositorio.Adicionar(_carroTest);

            var todosCarros = _contextoTeste.Carros.ToList();

            Assert.AreEqual(2, todosCarros.Count);
        }
        [TestMethod]
        public void Deveria_editar_um_Carro()
        {
            var carroEditado = _contextoTeste.Carros.Find(1);
            carroEditado.Marca = "EDITADO";

            _repositorio.Editar(carroEditado);

            var carrobuscado = _contextoTeste.Carros.Find(1);

            Assert.AreEqual("EDITADO", carrobuscado.Marca); ;
        }
        [TestMethod]
        public void Deveria_deletar_um_carro()
        {
            var carrodeletado = _contextoTeste.Carros.Add(ConstrutorObjeto.CriarCarro());

            _repositorio.Deletar(carrodeletado);

            var todosCarros = _contextoTeste.Carros.ToList();

            Assert.AreNotEqual(carrodeletado, todosCarros.Last());
        }
        [TestMethod]
        public void Deveria_buscar_todos_os_carros()
        {
            var carrosBuscados = _repositorio.BuscarTudo();
            Assert.IsNotNull(carrosBuscados);
        }
        [TestMethod]
        public void Deveria_buscar_carros_por_id()
        {
            var carrosBuscados = _repositorio.BuscarPor(1);
            Assert.IsNotNull(carrosBuscados);

        }
        [TestMethod]
        public void Deveria_buscar_carro_por_placa()
        {

            var carroBuscado = _repositorio.BuscarPorPlaca("JKT2536");

            Assert.IsNotNull(carroBuscado);
        }
        [TestMethod]
        public void Deveria_buscar_carro_por_modelo()
        {

            var carroBuscado = _repositorio.BuscarPorModelo("Palio Weekend");

            Assert.IsNotNull(carroBuscado);
        }
    }
}
