using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sampe
{
    public partial class sampeContext : DbContext
    {
        public virtual DbSet<Atividade> Atividade { get; set; }
        public virtual DbSet<AtividadeFormaulario> AtividadeFormaulario { get; set; }
        public virtual DbSet<AtividadeMaquina> AtividadeMaquina { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<FormularioOrdemServico> FormularioOrdemServico { get; set; }
        public virtual DbSet<FormularioTrocaMolde> FormularioTrocaMolde { get; set; }
        public virtual DbSet<Hierarquia> Hierarquia { get; set; }
        public virtual DbSet<Maquina> Maquina { get; set; }
        public virtual DbSet<Molde> Molde { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("User Id = root; Host = localhost; Database = sampe;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atividade>(entity =>
            {
                entity.HasKey(e => e.IdAtividade);

                entity.ToTable("atividade", "sampe");

                entity.Property(e => e.IdAtividade)
                    .HasColumnName("id_atividade")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.NomeAtividade)
                    .HasColumnName("nome_atividade")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<AtividadeFormaulario>(entity =>
            {
                entity.HasKey(e => e.IdAtividadeFormaulario);

                entity.ToTable("atividade_formaulario", "sampe");

                entity.Property(e => e.IdAtividadeFormaulario)
                    .HasColumnName("id_atividade_formaulario")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.IdAtividade)
                    .HasColumnName("id_atividade")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.IdFormaulario)
                    .HasColumnName("id_formaulario")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.StatusAtividade).HasColumnName("status_atividade");
            });

            modelBuilder.Entity<AtividadeMaquina>(entity =>
            {
                entity.HasKey(e => e.IdAtividadeMaquinaMolde);

                entity.ToTable("atividade_maquina", "sampe");

                entity.Property(e => e.IdAtividadeMaquinaMolde)
                    .HasColumnName("id_atividade_maquina_molde")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.IdAtividade)
                    .IsRequired()
                    .HasColumnName("id_atividade")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.IdMaquina)
                    .IsRequired()
                    .HasColumnName("id_maquina")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.StatusAtividade).HasColumnName("status_atividade");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo);

                entity.ToTable("cargo", "sampe");

                entity.Property(e => e.IdCargo).HasColumnName("ID_CARGO");

                entity.Property(e => e.DescricaoCargo)
                    .IsRequired()
                    .HasColumnName("DESCRICAO_CARGO")
                    .HasColumnType("varchar")
                    .HasMaxLength(30);

                entity.Property(e => e.NomeCargo)
                    .IsRequired()
                    .HasColumnName("NOME_CARGO")
                    .HasColumnType("varchar")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<FormularioOrdemServico>(entity =>
            {
                entity.HasKey(e => e.IdOrdemServico);

                entity.ToTable("formulario_ordem_servico", "sampe");

                entity.Property(e => e.IdOrdemServico)
                    .HasColumnName("id_ordem_servico")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.Dt)
                    .IsRequired()
                    .HasColumnName("dt")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.HoraFinal)
                    .IsRequired()
                    .HasColumnName("hora_final")
                    .HasColumnType("varchar")
                    .HasMaxLength(5);

                entity.Property(e => e.HoraInico)
                    .IsRequired()
                    .HasColumnName("hora_inico")
                    .HasColumnType("varchar")
                    .HasMaxLength(5);

                entity.Property(e => e.IdExecutante)
                    .IsRequired()
                    .HasColumnName("id_executante")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.IdSupervisor)
                    .IsRequired()
                    .HasColumnName("id_supervisor")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.Intervalo).HasColumnName("intervalo");

                entity.Property(e => e.IntervaloFim)
                    .HasColumnName("intervalo_fim")
                    .HasColumnType("varchar")
                    .HasMaxLength(5);

                entity.Property(e => e.IntervaloInicio)
                    .HasColumnName("intervalo_inicio")
                    .HasColumnType("varchar")
                    .HasMaxLength(5);

                entity.Property(e => e.Maquina)
                    .IsRequired()
                    .HasColumnName("maquina")
                    .HasColumnType("varchar")
                    .HasMaxLength(15);

                entity.Property(e => e.ObsIntervalo).HasColumnName("obs_intervalo");

                entity.Property(e => e.TipoManutencao)
                    .IsRequired()
                    .HasColumnName("tipo_manutencao")
                    .HasColumnType("varchar")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<FormularioTrocaMolde>(entity =>
            {
                entity.HasKey(e => e.IdTrocaDeMolde);

                entity.ToTable("formulario_troca_molde", "sampe");

                entity.Property(e => e.IdTrocaDeMolde)
                    .HasColumnName("id_troca_de_molde")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.Dt)
                    .IsRequired()
                    .HasColumnName("dt")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.HoraFinal)
                    .IsRequired()
                    .HasColumnName("hora_final")
                    .HasColumnType("varchar")
                    .HasMaxLength(5);

                entity.Property(e => e.HoraInico)
                    .IsRequired()
                    .HasColumnName("hora_inico")
                    .HasColumnType("varchar")
                    .HasMaxLength(5);

                entity.Property(e => e.IdExecutante)
                    .IsRequired()
                    .HasColumnName("id_executante")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.IdSupervisor)
                    .HasColumnName("id_supervisor")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.Intervalo).HasColumnName("intervalo");

                entity.Property(e => e.IntervaloFim)
                    .HasColumnName("intervalo_fim")
                    .HasColumnType("varchar")
                    .HasMaxLength(5);

                entity.Property(e => e.IntervaloInicio)
                    .HasColumnName("intervalo_inicio")
                    .HasColumnType("varchar")
                    .HasMaxLength(5);

                entity.Property(e => e.Maquina)
                    .IsRequired()
                    .HasColumnName("maquina")
                    .HasColumnType("varchar")
                    .HasMaxLength(15);

                entity.Property(e => e.Molde)
                    .IsRequired()
                    .HasColumnName("molde")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.ObsIntervalo).HasColumnName("obs_intervalo");
            });

            modelBuilder.Entity<Hierarquia>(entity =>
            {
                entity.HasKey(e => e.IdHierarquia);

                entity.ToTable("hierarquia", "sampe");

                entity.Property(e => e.IdHierarquia).HasColumnName("ID_HIERARQUIA");

                entity.Property(e => e.DescricaoHierarquia).HasColumnName("DESCRICAO_HIERARQUIA");

                entity.Property(e => e.NomeHierarquia)
                    .IsRequired()
                    .HasColumnName("NOME_HIERARQUIA")
                    .HasColumnType("varchar")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.HasKey(e => e.IdMaquina);

                entity.ToTable("maquina", "sampe");

                entity.Property(e => e.IdMaquina)
                    .HasColumnName("id_maquina")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.NomeMaquina)
                    .IsRequired()
                    .HasColumnName("nome_maquina")
                    .HasColumnType("varchar")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Molde>(entity =>
            {
                entity.HasKey(e => e.IdMolde);

                entity.ToTable("molde", "sampe");

                entity.Property(e => e.IdMolde)
                    .HasColumnName("id_molde")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.Cavidade).HasColumnName("cavidade");

                entity.Property(e => e.NomeMolde)
                    .IsRequired()
                    .HasColumnName("nome_molde")
                    .HasColumnType("varchar")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuario", "sampe");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.Property(e => e.IdCargo).HasColumnName("ID_CARGO");

                entity.Property(e => e.IdHierarquia).HasColumnName("ID_HIERARQUIA");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasColumnName("NOME_USUARIO")
                    .HasColumnType("varchar")
                    .HasMaxLength(30);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasColumnType("varchar")
                    .HasMaxLength(30);
            });
        }
    }
}
