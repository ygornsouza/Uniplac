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
    public class EmpresaRepositorio : IRepositorioEmpresa
    {
        public GerenciadorDeFrotaContexto _contexto;

        public EmpresaRepositorio(GerenciadorDeFrotaContexto contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Empresa entidade)
        {
            _contexto.Empresas.Add(entidade);

            _contexto.SaveChanges();
        }

        public Empresa BuscarPor(int id)
        {
            return _contexto.Empresas.Find(id);
        }

        public Empresa BuscarPorCNPJ(string CNPJ)
        {
            return _contexto.Empresas
                .Where(p => p.CNPJ == CNPJ)
                .FirstOrDefault();
        }

        public Empresa BuscarPorNome(string Nome)
        {
            return _contexto.Empresas
                .Where(p => p.Nome == Nome)
                .FirstOrDefault();
        }

        public List<Empresa> BuscarTudo()
        {
            return _contexto.Empresas.ToList();
        }

        public void Deletar(Empresa entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Empresas.Attach(entidade);
            }

            _contexto.Empresas.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Empresa entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Empresas.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
