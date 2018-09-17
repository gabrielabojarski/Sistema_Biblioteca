namespace MundoNovo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criarNovoBancoXabu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bibliotecarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        login = c.String(),
                        guid = c.String(),
                        senha = c.String(),
                        nome = c.String(),
                        matricula = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Emprestimos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        valor = c.Double(nullable: false),
                        dataPrazo = c.String(),
                        dataDevolucao = c.String(),
                        status = c.Int(nullable: false),
                        cep = c.String(),
                        endereco = c.String(),
                        nome = c.String(),
                        Logradouro = c.String(),
                        Bairro = c.String(),
                        Localidade = c.String(),
                        Uf = c.String(),
                        bibliotecario_id = c.Int(),
                        livro_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Bibliotecarios", t => t.bibliotecario_id)
                .ForeignKey("dbo.Livros", t => t.livro_id)
                .Index(t => t.bibliotecario_id)
                .Index(t => t.livro_id);
            
            CreateTable(
                "dbo.Livros",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                        autor = c.String(),
                        ano = c.DateTime(nullable: false),
                        descricao = c.String(),
                        bibliotecario_id = c.Int(),
                        categoria_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Bibliotecarios", t => t.bibliotecario_id)
                .ForeignKey("dbo.Categorias", t => t.categoria_id)
                .Index(t => t.bibliotecario_id)
                .Index(t => t.categoria_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emprestimos", "livro_id", "dbo.Livros");
            DropForeignKey("dbo.Livros", "categoria_id", "dbo.Categorias");
            DropForeignKey("dbo.Livros", "bibliotecario_id", "dbo.Bibliotecarios");
            DropForeignKey("dbo.Emprestimos", "bibliotecario_id", "dbo.Bibliotecarios");
            DropIndex("dbo.Livros", new[] { "categoria_id" });
            DropIndex("dbo.Livros", new[] { "bibliotecario_id" });
            DropIndex("dbo.Emprestimos", new[] { "livro_id" });
            DropIndex("dbo.Emprestimos", new[] { "bibliotecario_id" });
            DropTable("dbo.Livros");
            DropTable("dbo.Emprestimos");
            DropTable("dbo.Categorias");
            DropTable("dbo.Bibliotecarios");
        }
    }
}
