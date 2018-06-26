using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Avaliacao.Dominio.Contratos;
using Uniplac.Avaliacao.Dominio.Entidades;
using Uniplac.Avaliacao.Infra.Dados.Contexto;

namespace Uniplac.Avaliacao.Infra.Dados.Repositorios
{
    public class CarroRepositorio : IRepositorioCarro
    {
        public GerenciadorDeFrotaContexto _contexto;

        public CarroRepositorio(GerenciadorDeFrotaContexto contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(Carro entidade)
        {
            _contexto.Carros.Add(entidade);

            _contexto.SaveChanges();
        }

        public Carro BuscarPor(int id)
        {
            return _contexto.Carros.Find(id);
        }

        public Carro BuscarPorModelo(string modelo)
        {
            return _contexto.Carros
                .Where(p => p.Modelo == modelo)
                .FirstOrDefault();
        }

        public Carro BuscarPorPlaca(string placa)
        {
            return _contexto.Carros
               .Where(p => p.Placa == placa)
               .FirstOrDefault();
        }

        public List<Carro> BuscarTudo()
        {
            return _contexto.Carros.ToList();
        }

        public void Deletar(Carro entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Carros.Attach(entidade);
            }

            _contexto.Carros.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Carro entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Carros.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
