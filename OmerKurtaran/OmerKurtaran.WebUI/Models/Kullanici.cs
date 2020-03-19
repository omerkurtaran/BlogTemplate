namespace OmerKurtaran.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        public Kullanici()
        {
            KayitTarihi = DateTime.Now;
            Rols = new HashSet<Rol>();
            Makales = new HashSet<Makale>();
        }
        [Key]
        public int KullaniciId { get; set; }

        [Required]
        [StringLength(100)]
        public string Adi { get; set; }

        [Required]
        [StringLength(100)]
        public string Soyadi { get; set; }

        [Required]
        [StringLength(100)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(200)]
        public string Parola { get; set; }

        [Required]
        [StringLength(100)]
        public string MailAdres { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public bool? Yazar { get; set; }

        public bool? Onaylandi { get; set; }

        public bool? Aktif { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime? KayitTarihi { get; set; }

        public virtual ICollection<Rol> Rols { get; set; }

        public virtual ICollection<Makale> Makales { get; set; }


    }
}
