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
            EklenmeTarihi = DateTime.Now;
        }
        [Key]
        public int MakaleId { get; set; }

        [Required]
        [StringLength(100)]
        public string Baslik { get; set; }

        [Required]
        public string Icerik { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime EklenmeTarihi { get; set; }

        [DefaultValue(0)]
        public int? KategoriID { get; set; }

        [DefaultValue(0)]
        public int? GoruntulenmeSayisi { get; set; }

        [DefaultValue(0)]
        public int? Begeni { get; set; }
       
        [ForeignKey("Kullanici")]
        public int? KullaniciID { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Kategori Kategori { get; set; }

        [ForeignKey("Resim")]
        public int? ResimID { get; set; }

        public virtual Resim Resim { get; set; }

        public virtual ICollection<Yorum> Yorums { get; set; }

        public virtual ICollection<Etiket> Etikets { get; set; }
    }
}
