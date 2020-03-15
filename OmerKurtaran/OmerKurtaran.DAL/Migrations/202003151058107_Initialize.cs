namespace OmerKurtaran.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etiket",
                c => new
                    {
                        EtiketId = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.EtiketId);
            
            CreateTable(
                "dbo.Makale",
                c => new
                    {
                        MakaleId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false, maxLength: 100),
                        Icerik = c.String(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        KategoriID = c.Int(nullable: false),
                        GoruntulenmeSayisi = c.Int(nullable: false),
                        Begeni = c.Int(nullable: false),
                        YazarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MakaleId)
                .ForeignKey("dbo.Kategori", t => t.KategoriID)
                .ForeignKey("dbo.Yazar", t => t.YazarID)
                .Index(t => t.KategoriID)
                .Index(t => t.YazarID);
            
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 100),
                        Aciklama = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.Resim",
                c => new
                    {
                        Resimıd = c.Int(nullable: false, identity: true),
                        KucukBoyut = c.String(maxLength: 250),
                        OrtaBoyut = c.String(maxLength: 250),
                        BuyukBoyut = c.String(maxLength: 250),
                        MakaleID = c.Int(),
                        Video = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Resimıd)
                .ForeignKey("dbo.Makale", t => t.MakaleID)
                .Index(t => t.MakaleID);
            
            CreateTable(
                "dbo.Yazar",
                c => new
                    {
                        YazarId = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 100),
                        Soyadi = c.String(nullable: false, maxLength: 100),
                        MailAdres = c.String(nullable: false, maxLength: 100),
                        Aciklama = c.String(),
                        Cinsiyet = c.Boolean(),
                    })
                .PrimaryKey(t => t.YazarId);
            
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        KullaniciId = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 100),
                        Soyadi = c.String(nullable: false, maxLength: 100),
                        KullaniciAdi = c.String(nullable: false, maxLength: 100),
                        Parola = c.String(nullable: false, maxLength: 200),
                        MailAdres = c.String(nullable: false, maxLength: 100),
                        Cinsiyet = c.Boolean(),
                        DogumTarihi = c.DateTime(),
                        KayitTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KullaniciId);
            
            CreateTable(
                "dbo.Yorum",
                c => new
                    {
                        YorumId = c.Int(nullable: false, identity: true),
                        Yorum = c.String(nullable: false, maxLength: 1500),
                        MakaleID = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(),
                        AdSoyad = c.String(nullable: false, maxLength: 150),
                        Begeni = c.Int(),
                    })
                .PrimaryKey(t => t.YorumId)
                .ForeignKey("dbo.Makale", t => t.MakaleID)
                .Index(t => t.MakaleID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.YazarTakip",
                c => new
                    {
                        KullaniciID = c.Int(nullable: false),
                        YazarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KullaniciID, t.YazarID })
                .ForeignKey("dbo.Kullanici", t => t.KullaniciID, cascadeDelete: true)
                .ForeignKey("dbo.Yazar", t => t.YazarID, cascadeDelete: true)
                .Index(t => t.KullaniciID)
                .Index(t => t.YazarID);
            
            CreateTable(
                "dbo.MakaleEtiket",
                c => new
                    {
                        EtiketId = c.Int(nullable: false),
                        MakaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EtiketId, t.MakaleId })
                .ForeignKey("dbo.Etiket", t => t.EtiketId, cascadeDelete: true)
                .ForeignKey("dbo.Makale", t => t.MakaleId, cascadeDelete: true)
                .Index(t => t.EtiketId)
                .Index(t => t.MakaleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MakaleEtiket", "MakaleId", "dbo.Makale");
            DropForeignKey("dbo.MakaleEtiket", "EtiketId", "dbo.Etiket");
            DropForeignKey("dbo.Yorum", "MakaleID", "dbo.Makale");
            DropForeignKey("dbo.Makale", "YazarID", "dbo.Yazar");
            DropForeignKey("dbo.YazarTakip", "YazarID", "dbo.Yazar");
            DropForeignKey("dbo.YazarTakip", "KullaniciID", "dbo.Kullanici");
            DropForeignKey("dbo.Resim", "MakaleID", "dbo.Makale");
            DropForeignKey("dbo.Makale", "KategoriID", "dbo.Kategori");
            DropIndex("dbo.MakaleEtiket", new[] { "MakaleId" });
            DropIndex("dbo.MakaleEtiket", new[] { "EtiketId" });
            DropIndex("dbo.YazarTakip", new[] { "YazarID" });
            DropIndex("dbo.YazarTakip", new[] { "KullaniciID" });
            DropIndex("dbo.Yorum", new[] { "MakaleID" });
            DropIndex("dbo.Resim", new[] { "MakaleID" });
            DropIndex("dbo.Makale", new[] { "YazarID" });
            DropIndex("dbo.Makale", new[] { "KategoriID" });
            DropTable("dbo.MakaleEtiket");
            DropTable("dbo.YazarTakip");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Yorum");
            DropTable("dbo.Kullanici");
            DropTable("dbo.Yazar");
            DropTable("dbo.Resim");
            DropTable("dbo.Kategori");
            DropTable("dbo.Makale");
            DropTable("dbo.Etiket");
        }
    }
}
