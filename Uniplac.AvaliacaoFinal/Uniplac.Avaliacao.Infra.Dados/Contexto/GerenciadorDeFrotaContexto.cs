using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Avaliacao.Dominio.Entidades;

namespace Uniplac.Avaliacao.Infra.Dados.Contexto
{
    public class GerenciadorDeFrotaContexto: DbContext
    {
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        public GerenciadorDeFrotaContexto() : base("TrabalhoFinal_Ygor")
        {
            Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .ToTable("TBFuncionarios");

            modelBuilder.Entity<Carro>()
                .ToTable("TBCarros");

            modelBuilder.Entity<Empresa>()
                .ToTable("TBEmpresas");

            modelBuilder.Entity<Reserva>()
                .ToTable("TBReservas");

            modelBuilder.Entity<Funcionario>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Funcionario>()
                .Property(p => p.Nome)
                  .HasColumnType("varchar")
                  .HasMaxLength(150)
                  .IsRequired();

            modelBuilder.Entity<Funcionario>()
                .Property(p => p.CPF)
                  .HasColumnType("varchar")
                  .HasMaxLength(15)
                  .IsRequired();

            modelBuilder.Entity<Funcionario>()
                .Property(p => p.Cargo)
                  .HasColumnType("varchar")
                  .HasMaxLength(21)
                  .IsRequired();
            
            modelBuilder.Entity<Funcionario>()
                .Property(p => p.NumeroDeRegistro)
                  .IsRequired();



            modelBuilder.Entity<Carro>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Carro>()
                .Property(p => p.Ano)
                  .HasColumnType("varchar")
                  .HasMaxLength(4)
                  .IsRequired();


            modelBuilder.Entity<Carro>()
                .Property(p => p.Marca)
                  .HasColumnType("varchar")
                  .HasMaxLength(25)
                  .IsRequired();

            modelBuilder.Entity<Carro>()
                .Property(p => p.Modelo)
                  .HasColumnType("varchar")
                  .HasMaxLength(50)
                  .IsRequired();

            modelBuilder.Entity<Carro>()
                .Property(p => p.Placa)
                  .HasColumnType("varchar")
                  .HasMaxLength(7)
                  .IsRequired();


            modelBuilder.Entity<Reserva>()
                .HasKey(p => p.Id);


            modelBuilder.Entity<Reserva>()
                .Property(p => p.Observacao)
                  .HasColumnType("varchar")
                  .HasMaxLength(250);


            modelBuilder.Entity<Empresa>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Empresa>()
                .Property(p => p.Nome)
                  .HasColumnType("varchar")
                  .HasMaxLength(100)
                  .IsRequired();

            modelBuilder.Entity<Empresa>()
                .Property(p => p.CNPJ)
                  .HasColumnType("varchar")
                  .HasMaxLength(15)
                  .IsRequired();
        }

    }
}
