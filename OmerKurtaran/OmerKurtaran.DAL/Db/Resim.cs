namespace OmerKurtaran.DAL.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resim")]
    public partial class Resim
    {
        [Key]
        public int Resimıd { get; set; }

        [StringLength(250)]
        public string KucukBoyut { get; set; }

        [StringLength(250)]
        public string OrtaBoyut { get; set; }

        [StringLength(250)]
        public string BuyukBoyut { get; set; }

        public int? MakaleID { get; set; }

        [StringLength(250)]
        public string Video { get; set; }

        public virtual Makale Makale { get; set; }
    }
}
