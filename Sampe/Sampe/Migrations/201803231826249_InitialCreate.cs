namespace Sampe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AtividadeFormularioOS",
                c => new
                    {
                        AtividadeFormularioOSId = c.Int(nullable: false, identity: true),
                        AtividadeOSId = c.Int(nullable: false),
                        StatusAtividadeOS = c.Boolean(nullable: false),
                        FormularioOrdemServicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AtividadeFormularioOSId)
                .ForeignKey("dbo.FormularioOrdemServicoes", t => t.FormularioOrdemServicoId, cascadeDelete: true)
                .Index(t => t.FormularioOrdemServicoId);
            
            CreateTable(
                "dbo.FormularioOrdemServicoes",
                c => new
                    {
                        FormularioOrdemServicoId = c.Int(nullable: false, identity: true),
                        TipoManutencao = c.String(),
                        HoraInicio = c.String(),
                        HoraFinal = c.String(),
                        Dt = c.String(),
                        Intervalo = c.Boolean(nullable: false),
                        IntervaloInicio = c.String(),
                        IntervaloFim = c.String(),
                        ObsIntervalo = c.String(),
                        Executante = c.String(),
                        MaquinaId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FormularioOrdemServicoId)
                .ForeignKey("dbo.Maquinas", t => t.MaquinaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.MaquinaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Maquinas",
                c => new
                    {
                        MaquinaId = c.Int(nullable: false, identity: true),
                        NomeMaquina = c.String(),
                    })
                .PrimaryKey(t => t.MaquinaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        NomeUsuario = c.String(nullable: false),
                        SobrenomeUsuario = c.String(nullable: false),
                        Login = c.Int(nullable: false),
                        Senha = c.Int(nullable: false),
                        Hierarquia = c.String(),
                        CargoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Cargoes", t => t.CargoId, cascadeDelete: true)
                .Index(t => t.CargoId);
            
            CreateTable(
                "dbo.Cargoes",
                c => new
                    {
                        CargoId = c.Int(nullable: false, identity: true),
                        NomeCargo = c.String(),
                        DescricaoCargo = c.String(),
                    })
                .PrimaryKey(t => t.CargoId);
            
            CreateTable(
                "dbo.AtividadeFormularioTMs",
                c => new
                    {
                        AtividadeFormularioTMId = c.Int(nullable: false, identity: true),
                        AtividadeTMId = c.Int(nullable: false),
                        StatusAtividadeTM = c.Boolean(nullable: false),
                        FormularioTrocaMoldeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AtividadeFormularioTMId)
                .ForeignKey("dbo.FormularioTrocaMoldes", t => t.FormularioTrocaMoldeId, cascadeDelete: true)
                .Index(t => t.FormularioTrocaMoldeId);
            
            CreateTable(
                "dbo.FormularioTrocaMoldes",
                c => new
                    {
                        FormularioTrocaMoldeId = c.Int(nullable: false, identity: true),
                        DtRetirada = c.String(),
                        DtColocar = c.String(),
                        ColocarInicio = c.String(),
                        ColocarFim = c.String(),
                        RetirarInicio = c.String(),
                        RetirarFim = c.String(),
                        Executante = c.String(),
                        MoldeId = c.Int(nullable: false),
                        MaquinaId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FormularioTrocaMoldeId)
                .ForeignKey("dbo.Maquinas", t => t.MaquinaId, cascadeDelete: true)
                .ForeignKey("dbo.Moldes", t => t.MoldeId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.MoldeId)
                .Index(t => t.MaquinaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Moldes",
                c => new
                    {
                        MoldeId = c.Int(nullable: false, identity: true),
                        NomeMolde = c.String(),
                        Cavidade = c.Int(),
                    })
                .PrimaryKey(t => t.MoldeId);
            
            CreateTable(
                "dbo.Atividades",
                c => new
                    {
                        AtividadeId = c.Int(nullable: false, identity: true),
                        NomeAtividade = c.String(),
                    })
                .PrimaryKey(t => t.AtividadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AtividadeFormularioTMs", "FormularioTrocaMoldeId", "dbo.FormularioTrocaMoldes");
            DropForeignKey("dbo.FormularioTrocaMoldes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.FormularioTrocaMoldes", "MoldeId", "dbo.Moldes");
            DropForeignKey("dbo.FormularioTrocaMoldes", "MaquinaId", "dbo.Maquinas");
            DropForeignKey("dbo.AtividadeFormularioOS", "FormularioOrdemServicoId", "dbo.FormularioOrdemServicoes");
            DropForeignKey("dbo.FormularioOrdemServicoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "CargoId", "dbo.Cargoes");
            DropForeignKey("dbo.FormularioOrdemServicoes", "MaquinaId", "dbo.Maquinas");
            DropIndex("dbo.FormularioTrocaMoldes", new[] { "UsuarioId" });
            DropIndex("dbo.FormularioTrocaMoldes", new[] { "MaquinaId" });
            DropIndex("dbo.FormularioTrocaMoldes", new[] { "MoldeId" });
            DropIndex("dbo.AtividadeFormularioTMs", new[] { "FormularioTrocaMoldeId" });
            DropIndex("dbo.Usuarios", new[] { "CargoId" });
            DropIndex("dbo.FormularioOrdemServicoes", new[] { "UsuarioId" });
            DropIndex("dbo.FormularioOrdemServicoes", new[] { "MaquinaId" });
            DropIndex("dbo.AtividadeFormularioOS", new[] { "FormularioOrdemServicoId" });
            DropTable("dbo.Atividades");
            DropTable("dbo.Moldes");
            DropTable("dbo.FormularioTrocaMoldes");
            DropTable("dbo.AtividadeFormularioTMs");
            DropTable("dbo.Cargoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Maquinas");
            DropTable("dbo.FormularioOrdemServicoes");
            DropTable("dbo.AtividadeFormularioOS");
        }
    }
}
