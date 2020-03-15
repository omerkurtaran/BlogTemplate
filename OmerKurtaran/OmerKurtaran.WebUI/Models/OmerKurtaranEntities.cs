namespace OmerKurtaran.WebUI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OmerKurtaranEntities : DbContext
    {
        public OmerKurtaranEntities()
            : base("name=OmerKurtaranEntities")
        {
        }

        public virtual DbSet<Etiket> Etikets { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Makale> Makales { get; set; }
        public virtual DbSet<Resim> Resims { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Yazar> Yazars { get; set; }
        public virtual DbSet<Yorum> Yorums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.Makales)
                .WithMany(e => e.Etikets)
                .Map(m => m.ToTable("MakaleEtiket").MapLeftKey("EtiketId").MapRightKey("MakaleId"));

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Makales)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Yazars)
                .WithMany(e => e.Kullanicis)
                .Map(m => m.ToTable("YazarTakip").MapLeftKey("KullaniciID").MapRightKey("YazarID"));

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Resims)
                .WithOptional(e => e.Makale)
                .HasForeignKey(e => e.MakaleID);

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Yorums)
                .WithRequired(e => e.Makale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resim>()
                .HasMany(e => e.Makales)
                .WithRequired(e => e.Resim)
                .HasForeignKey(e => e.ResimID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Yazar>()
                .HasMany(e => e.Makales)
                .WithRequired(e => e.Yazar)
                .WillCascadeOnDelete(false);
        }
    }
}
