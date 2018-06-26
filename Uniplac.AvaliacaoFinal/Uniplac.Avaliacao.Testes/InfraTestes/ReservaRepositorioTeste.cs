using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Avaliacao.Infra.Dados.Contexto;
using Uniplac.Avaliacao.Infra.Dados.Repositorios;
using Uniplac.Avaliacao.Dominio.Entidades;
using Uniplac.Avaliacao.Testes.Base;
using System.Data.Entity;
using System.Linq;

namespace Uniplac.Avaliacao.Testes.InfraTestes
{
    /// <summary>
    /// Summary description for ReservaRepositorioTeste
    /// </summary>
    [TestClass]
    public class ReservaRepositorioTeste
    {
        private GerenciadorDeFrotaContexto _contextoTeste;
        private ReservaRepositorio _repositorio;
        private Reserva _reservaTest;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<GerenciadorDeFrotaContexto>());

            _contextoTeste = new GerenciadorDeFrotaContexto();

            _repositorio = new ReservaRepositorio(_contextoTeste);

            _reservaTest = ConstrutorObjeto.CriarReserva();

            _contextoTeste.Database.Initialize(true);
        }
        [TestMethod]
        public void Deveria_adicionar_uma_nova_reserva()
        {
            _repositorio.Adicionar(_reservaTest);

            var todasReservas = _contextoTeste.Reservas.ToList();

            Assert.AreEqual(2, todasReservas.Count);
        }
        [TestMethod]
        public void Deveria_editar_uma_reserva()
        {
            var reservaEditada = _contextoTeste.Reservas.Find(1);
            reservaEditada.Observacao = "EDITADO";

            _repositorio.Editar(reservaEditada);

            var reservaBuscada = _contextoTeste.Reservas.Find(1);

            Assert.AreEqual("EDITADO", reservaBuscada.Observacao); ;
        }
        [TestMethod]
        public void Deveria_deletar_um_carro()
        {
            var reservaDeletada = _contextoTeste.Reservas.Add(ConstrutorObjeto.CriarReserva());

            _repositorio.Deletar(reservaDeletada);

            var todasReservas = _contextoTeste.Reservas.ToList();

            Assert.AreNotEqual(reservaDeletada, todasReservas.Last());
        }
        [TestMethod]
        public void Deveria_buscar_todos_as_reservas()
        {
            var todasReservas = _repositorio.BuscarTudo();
            Assert.IsNotNull(todasReservas);
        }
        [TestMethod]
        public void Deveria_buscar_reserva_por_id()
        {
            var reservaBuscada = _repositorio.BuscarPor(1);
            Assert.IsNotNull(reservaBuscada);

        }
    }
}
