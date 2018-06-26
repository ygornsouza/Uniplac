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
    public class ReservaRepositorio : IRepositorioReserva
    {
        public GerenciadorDeFrotaContexto _contexto;
        public ReservaRepositorio(GerenciadorDeFrotaContexto contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Reserva entidade)
        {
            _contexto.Reservas.Add(entidade);

            _contexto.SaveChanges();
        }

        public Reserva BuscarPor(int id)
        {
            return _contexto.Reservas.Find(id);
        }

        public List<Reserva> BuscarTudo()
        {
            return _contexto.Reservas.ToList();
        }

        

        public void Deletar(Reserva entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Reservas.Attach(entidade);
            }

            _contexto.Reservas.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Reserva entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Reservas.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
