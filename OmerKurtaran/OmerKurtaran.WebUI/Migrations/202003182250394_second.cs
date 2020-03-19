namespace OmerKurtaran.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MakaleEtiket", newName: "MakaleEtikets");
            DropForeignKey("dbo.Kullanici", "Rol_RolId", "dbo.Rol");
            DropForeignKey("dbo.Makale", "ResimID", "dbo.Resim");
            DropForeignKey("dbo.Resim", "MakaleID", "dbo.Makale");
            DropForeignKey("dbo.Yorum", "MakaleID", "dbo.Makale");
            DropIndex("dbo.Makale", new[] { "KategoriID" });
            DropIndex("dbo.Makale", new[] { "ResimID" });
            DropIndex("dbo.Resim", new[] { "MakaleID" });
            DropIndex("dbo.Kullanici", new[] { "Rol_RolId" });
            RenameColumn(table: "dbo.MakaleEtikets", name: "EtiketId", newName: "Etiket_EtiketId");
            RenameColumn(table: "dbo.MakaleEtikets", name: "MakaleId", newName: "Makale_MakaleId");
            RenameIndex(table: "dbo.MakaleEtikets", name: "IX_MakaleId", newName: "IX_Makale_MakaleId");
            RenameIndex(table: "dbo.MakaleEtikets", name: "IX_EtiketId", newName: "IX_Etiket_EtiketId");
            DropPrimaryKey("dbo.MakaleEtikets");
            CreateTable(
                "dbo.KullaniciRol",
                c => new
                    {
                        KullaniciRolId = c.Int(nullable: false, identity: true),
                        KullaniciId_KullaniciId = c.Int(),
                        RolId_RolId = c.Int(),
                    })
                .PrimaryKey(t => t.KullaniciRolId)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId_KullaniciId)
                .ForeignKey("dbo.Rol", t => t.RolId_RolId)
                .Index(t => t.KullaniciId_KullaniciId)
                .Index(t => t.RolId_RolId);
            
            AddColumn("dbo.Makale", "Resim_Resimıd", c => c.Int());
            AddColumn("dbo.Makale", "Resim_Resimıd1", c => c.Int());
            AddColumn("dbo.Resim", "Makale_MakaleId", c => c.Int());
            AddColumn("dbo.Resim", "Makale_MakaleId1", c => c.Int());
            AlterColumn("dbo.Makale", "KategoriID", c => c.Int());
            AlterColumn("dbo.Makale", "ResimID", c => c.Int());
            AddPrimaryKey("dbo.MakaleEtikets", new[] { "Makale_MakaleId", "Etiket_EtiketId" });
            CreateIndex("dbo.Makale", "KategoriID");
            CreateIndex("dbo.Makale", "Resim_Resimıd");
            CreateIndex("dbo.Makale", "Resim_Resimıd1");
            CreateIndex("dbo.Resim", "Makale_MakaleId");
            CreateIndex("dbo.Resim", "Makale_MakaleId1");
            AddForeignKey("dbo.Makale", "Resim_Resimıd1", "dbo.Resim", "Resimıd");
            AddForeignKey("dbo.Resim", "Makale_MakaleId1", "dbo.Makale", "MakaleId");
            AddForeignKey("dbo.Yorum", "MakaleID", "dbo.Makale", "MakaleId", cascadeDelete: true);
            AddForeignKey("dbo.Resim", "Makale_MakaleId", "dbo.Makale", "MakaleId");
            AddForeignKey("dbo.Makale", "Resim_Resimıd", "dbo.Resim", "Resimıd");
            //DropColumn("dbo.Kullanici", "Rol_RolId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kullanici", "Rol_RolId", c => c.Int());
            DropForeignKey("dbo.Makale", "Resim_Resimıd", "dbo.Resim");
            DropForeignKey("dbo.Resim", "Makale_MakaleId", "dbo.Makale");
            DropForeignKey("dbo.Yorum", "MakaleID", "dbo.Makale");
            DropForeignKey("dbo.Resim", "Makale_MakaleId1", "dbo.Makale");
            DropForeignKey("dbo.Makale", "Resim_Resimıd1", "dbo.Resim");
            DropForeignKey("dbo.KullaniciRol", "RolId_RolId", "dbo.Rol");
            DropForeignKey("dbo.KullaniciRol", "KullaniciId_KullaniciId", "dbo.Kullanici");
            DropIndex("dbo.KullaniciRol", new[] { "RolId_RolId" });
            DropIndex("dbo.KullaniciRol", new[] { "KullaniciId_KullaniciId" });
            DropIndex("dbo.Resim", new[] { "Makale_MakaleId1" });
            DropIndex("dbo.Resim", new[] { "Makale_MakaleId" });
            DropIndex("dbo.Makale", new[] { "Resim_Resimıd1" });
            DropIndex("dbo.Makale", new[] { "Resim_Resimıd" });
            DropIndex("dbo.Makale", new[] { "KategoriID" });
            DropPrimaryKey("dbo.MakaleEtikets");
            AlterColumn("dbo.Makale", "ResimID", c => c.Int(nullable: false));
            AlterColumn("dbo.Makale", "KategoriID", c => c.Int(nullable: false));
            DropColumn("dbo.Resim", "Makale_MakaleId1");
            DropColumn("dbo.Resim", "Makale_MakaleId");
            DropColumn("dbo.Makale", "Resim_Resimıd1");
            DropColumn("dbo.Makale", "Resim_Resimıd");
            DropTable("dbo.KullaniciRol");
            AddPrimaryKey("dbo.MakaleEtikets", new[] { "EtiketId", "MakaleId" });
            RenameIndex(table: "dbo.MakaleEtikets", name: "IX_Etiket_EtiketId", newName: "IX_EtiketId");
            RenameIndex(table: "dbo.MakaleEtikets", name: "IX_Makale_MakaleId", newName: "IX_MakaleId");
            RenameColumn(table: "dbo.MakaleEtikets", name: "Makale_MakaleId", newName: "MakaleId");
            RenameColumn(table: "dbo.MakaleEtikets", name: "Etiket_EtiketId", newName: "EtiketId");
            CreateIndex("dbo.Kullanici", "Rol_RolId");
            CreateIndex("dbo.Resim", "MakaleID");
            CreateIndex("dbo.Makale", "ResimID");
            CreateIndex("dbo.Makale", "KategoriID");
            AddForeignKey("dbo.Yorum", "MakaleID", "dbo.Makale", "MakaleId");
            AddForeignKey("dbo.Resim", "MakaleID", "dbo.Makale", "MakaleId");
            AddForeignKey("dbo.Makale", "ResimID", "dbo.Resim", "Resimıd");
            AddForeignKey("dbo.Kullanici", "Rol_RolId", "dbo.Rol", "RolId");
            RenameTable(name: "dbo.MakaleEtikets", newName: "MakaleEtiket");
        }
    }
}
