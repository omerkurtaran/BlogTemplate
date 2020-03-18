namespace OmerKurtaran.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yazar")]
    public partial class Yazar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yazar()
        {
            Makales = new HashSet<Makale>();
            Kullanicis = new HashSet<Kullanici>();

        }

        [Key]
        public int YazarId { get; set; }

        [Required]
        [StringLength(100)]
        public string Adi { get; set; }

        [Required]
        [StringLength(100)]
        public string Soyadi { get; set; }

        [StringLength(100)]
        public string KullaniciAdi { get; set; }

        [StringLength(100)]
        public string Parola { get; set; }

        [Required]
        [StringLength(100)]
        public string MailAdres { get; set; }

        public string Aciklama { get; set; }

        public bool? Cinsiyet { get; set; }

        public Resim Resim { get; set; }

        public virtual ICollection<Makale> Makales { get; set; }

        public virtual ICollection<Kullanici> Kullanicis { get; set; }

    }
}
