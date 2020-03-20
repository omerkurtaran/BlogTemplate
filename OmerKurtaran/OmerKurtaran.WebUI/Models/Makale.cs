namespace OmerKurtaran.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Makale")]
    public partial class Makale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Makale()
        {
            Yorums = new HashSet<Yorum>();
            Etikets = new HashSet<Etiket>();
        }
        [Key]
        public int MakaleId { get; set; }

        [Required]
        [StringLength(100)]
        public string Baslik { get; set; }

        [Required]
        public string Icerik { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime EklenmeTarihi { get; set; }

        public int? KategoriID { get; set; }

        public int? GoruntulenmeSayisi { get; set; }

        public int? Begeni { get; set; }

        [ForeignKey("Kullanici")]
        public int? KullaniciID { get; set; }

        public Kullanici Kullanici { get; set; }
          
        public virtual Kategori Kategori { get; set; }

        [ForeignKey("Resim")]
        public int? ResimID { get; set; }

        public virtual Resim Resim { get; set; }

        public virtual ICollection<Yorum> Yorums { get; set; }

        public virtual ICollection<Etiket> Etikets { get; set; }
    }
}
