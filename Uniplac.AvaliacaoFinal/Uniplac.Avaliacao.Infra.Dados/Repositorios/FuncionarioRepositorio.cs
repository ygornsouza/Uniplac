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
    public class FuncionarioRepositorio : IRepositorioFuncionario
    {
        public GerenciadorDeFrotaContexto _contexto;

        public FuncionarioRepositorio(GerenciadorDeFrotaContexto contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(Funcionario entidade)
        {
            _contexto.Funcionarios.Add(entidade);

            _contexto.SaveChanges();
        }

        public Funcionario BuscarPor(int id)
        {
            return _contexto.Funcionarios.Find(id);
        }

        public Funcionario BuscarPorNome(string nome)
        {
            return _contexto.Funcionarios
                .Where(p => p.Nome == nome)
                .FirstOrDefault();
        }

        public Funcionario BuscarPorNumeroDeRegistro(int numeroDeRegistro)
        {
            return _contexto.Funcionarios.Where(p => p.NumeroDeRegistro == numeroDeRegistro)
                .FirstOrDefault();
        }

        public List<Funcionario> BuscarTudo()
        {
            return _contexto.Funcionarios.ToList();
        }

        public void Deletar(Funcionario entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Funcionarios.Attach(entidade);
            }

            _contexto.Funcionarios.Remove(entidade);

            _contexto.SaveChanges(); ;
        }

        public void Editar(Funcionario entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Funcionarios.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
