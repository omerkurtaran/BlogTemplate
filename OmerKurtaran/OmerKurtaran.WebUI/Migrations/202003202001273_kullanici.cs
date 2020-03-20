namespace OmerKurtaran.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kullanici : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Makale", "YazarID", "dbo.Kullanici");
            ////DropIndex("dbo.Makale", new[] { "YazarID" });
            ////DropColumn("dbo.Makale", "YazarID");
            //AddColumn("dbo.Makale", "KullaniciID", c => c.Int(nullable: false));
            //CreateIndex("dbo.Makale", "KullaniciID");
            //AddForeignKey("dbo.Makale", "KullaniciID", "dbo.Kullanici", "KullaniciId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Makale", "KullaniciID", "dbo.Kullanici");
            DropIndex("dbo.Makale", new[] { "KullaniciID" });
            DropColumn("dbo.Makale", "KullaniciID");
        }
    }
}
