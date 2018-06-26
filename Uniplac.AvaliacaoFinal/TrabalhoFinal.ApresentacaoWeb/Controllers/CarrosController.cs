using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Uniplac.Avaliacao.Dominio.Entidades;
using Uniplac.Avaliacao.Infra.Dados.Contexto;
using Uniplac.Avaliacao.Infra.Dados.Repositorios;

namespace TrabalhoFinal.ApresentacaoWeb.Controllers
{
    public class CarrosController : Controller
    {
        private static GerenciadorDeFrotaContexto contexto = new GerenciadorDeFrotaContexto();
        private CarroRepositorio db = new CarroRepositorio(contexto);

        // GET: Carros
        public ActionResult Index()
        {
            return View(db.BuscarTudo());
        }

        // GET: Carros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.BuscarPor((int)id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: Carros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marca,Ano,Modelo,Placa")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Adicionar(carro);
                
                return RedirectToAction("Index");
            }

            return View(carro);
        }

        // GET: Carros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.BuscarPor((int)id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marca,Ano,Modelo,Placa")] Carro carro)
        {
            Carro carroBuscado = db.BuscarPor(carro.Id);
            carroBuscado.Ano = carro.Ano;
            carroBuscado.Empresa = carro.Empresa;
            carroBuscado.Marca = carro.Marca;
            carroBuscado.Modelo = carro.Modelo;
            carroBuscado.Placa = carro.Placa;


            if (ModelState.IsValid)
            {
                db.Editar(carroBuscado);
                
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        // GET: Carros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.BuscarPor((int)id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = db.BuscarPor((int)id);
            db.Deletar(carro);
            
            return RedirectToAction("Index");
        }
    }
}
