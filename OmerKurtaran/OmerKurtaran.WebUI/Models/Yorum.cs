namespace OmerKurtaran.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        public Yorum()
        {
            EklenmeTarihi = DateTime.Now;
        }
        public int YorumId { get; set; }
   
        [Required]
        [StringLength(1500)]
        public string Ýcerik { get; set; }

        public int MakaleID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime? EklenmeTarihi { get; set; }

        [Required]
        [StringLength(150)]
        public string AdSoyad { get; set; }

        public int? Begeni { get; set; }

        public virtual Makale Makale { get; set; }
    }
}
