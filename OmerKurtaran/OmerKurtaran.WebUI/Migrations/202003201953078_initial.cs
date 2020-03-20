namespace OmerKurtaran.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Makale", "YazarID", "dbo.Kullanici");
            //DropIndex("dbo.Makale", new[] { "YazarID" });
            //DropColumn("dbo.Makale", "YazarID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Makale", "KullaniciID", c => c.Int());
            CreateIndex("dbo.Makale", "KullaniciID");
            AddForeignKey("dbo.Makale", "KullaniciID", "dbo.Kullanici", "KullaniciId");
        }
    }
}
